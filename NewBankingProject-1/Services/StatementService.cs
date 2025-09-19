using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using NewBankingProject_1.Data;
using NewBankingProject_1.Models;
using NewBankingProject_1.Models.Dtos;
using QuestPDF.Fluent;
using QuestPDF.Helpers;


namespace NewBankingProject_1.Services
{
    public class StatementService : IStatementService
    {
        private readonly BankingDbContext _db;
        public StatementService(BankingDbContext db) { _db = db; }

       
        private static (DateTime start, DateTime end) NormalizeRange(DateTime startDate, DateTime endDate)
        {
            var s = startDate.Date;
            var e = endDate.Date.AddDays(1).AddTicks(-1);
            return (s, e);
        }

        public async Task<AccountStatementDto> GetStatementAsync(int accountId, DateTime startDate, DateTime endDate)
        {
            var range = NormalizeRange(startDate, endDate);

            var account = await _db.Accounts
                .AsNoTracking()
                .Include(a => a.Transactions)
                .FirstOrDefaultAsync(a => a.AccountId == accountId);

            if (account == null) throw new KeyNotFoundException("Account not found.");

            
            var effectsFromStartToNow = await _db.Transactions
                .Where(t => t.AccountId == accountId && t.Date >= range.start)
                .AsNoTracking()
                .ToListAsync();

            decimal sumEffectsFromStartToNow = effectsFromStartToNow.Sum(t => IsDeposit(t) ? t.Amount : -t.Amount);
            decimal balanceBeforeStart = account.Balance - sumEffectsFromStartToNow;

            
            var trxInRange = await _db.Transactions
                .Where(t => t.AccountId == accountId && t.Date >= range.start && t.Date <= range.end)
                .OrderBy(t => t.Date)
                .AsNoTracking()
                .ToListAsync();

            decimal running = balanceBeforeStart;
            var lines = new List<StatementLineDto>();

            foreach (var t in trxInRange)
            {
                var effect = IsDeposit(t) ? t.Amount : -t.Amount;
                running += effect;

                lines.Add(new StatementLineDto
                {
                    Date = t.Date,
                    Debit = effect < 0 ? (decimal?)(-effect) : null,
                    Credit = effect > 0 ? (decimal?)effect : null,
                    Description = t.Description,
                    Balance = running,
                    Type = t.Type
                });
            }

            return new AccountStatementDto
            {
                AccountId = account.AccountId,
                AccountName = account.AccountName,
                AccountNumber = account.AccountNumber,
                CurrentBalance = account.Balance,
                Lines = lines
            };
        }

        public async Task<byte[]> GenerateExcelAsync(int accountId, DateTime startDate, DateTime endDate)
        {
            var statement = await GetStatementAsync(accountId, startDate, endDate);

            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Statement");

            // Header
            ws.Cell(1, 1).Value = "Date";
            ws.Cell(1, 2).Value = "Debit";
            ws.Cell(1, 3).Value = "Credit";
            ws.Cell(1, 4).Value = "Description";
            ws.Cell(1, 5).Value = "Balance";

            int row = 2;
            foreach (var l in statement.Lines)
            {
                ws.Cell(row, 1).Value = l.Date;
                ws.Cell(row, 1).Style.DateFormat.Format = "yyyy-MM-dd HH:mm";
                ws.Cell(row, 2).Value = l.Debit ?? 0;
                ws.Cell(row, 3).Value = l.Credit ?? 0;
                ws.Cell(row, 4).Value = l.Description ?? "";
                ws.Cell(row, 5).Value = l.Balance;
                row++;
            }

            ws.Columns().AdjustToContents();

            using var ms = new MemoryStream();
            workbook.SaveAs(ms);
            return ms.ToArray();
        }

        public async Task<byte[]> GeneratePdfAsync(int accountId, DateTime startDate, DateTime endDate)
        {
            var statement = await GetStatementAsync(accountId, startDate, endDate);

            var start = startDate.Date;
            var end = endDate.Date;

            var doc = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Size(PageSizes.A4);

                    page.Header().Element(h => h.Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text($"Statement for {statement.AccountName}").FontSize(16).Bold();
                            col.Item().Text($"Account: {statement.AccountNumber}");
                            col.Item().Text($"Period: {start:yyyy-MM-dd} to {end:yyyy-MM-dd}");
                            col.Item().Text($"Current Balance: {statement.CurrentBalance:C}");
                        });
                    }));

                    page.Content().Element(content =>
                    {
                        content.Column(col =>
                        {
                            
                            col.Item().Element(c => c.Row(header =>
                            {
                                header.ConstantItem(120).Text("Date").Bold();
                                header.RelativeItem().Text("Description").Bold();
                                header.ConstantItem(80).AlignRight().Text("Debit").Bold();
                                header.ConstantItem(80).AlignRight().Text("Credit").Bold();
                                header.ConstantItem(80).AlignRight().Text("Balance").Bold();
                            }));

                           
                            foreach (var l in statement.Lines)
                            {
                                col.Item().Element(c => c.Row(r =>
                                {
                                    r.ConstantItem(120).Text(l.Date.ToString("yyyy-MM-dd HH:mm"));
                                    r.RelativeItem().Text(l.Description ?? "");
                                    r.ConstantItem(80).AlignRight().Text(l.Debit?.ToString("F2") ?? "");
                                    r.ConstantItem(80).AlignRight().Text(l.Credit?.ToString("F2") ?? "");
                                    r.ConstantItem(80).AlignRight().Text(l.Balance.ToString("F2"));
                                }));
                            }
                        });
                    });

                    page.Footer().AlignCenter().Text(x => x.Span($"Generated: {DateTime.UtcNow:yyyy-MM-dd HH:mm}"));
                });
            });

            return doc.GeneratePdf();
        }

        private static bool IsDeposit(Transaction t)
        {
            return !string.IsNullOrWhiteSpace(t.Type) && t.Type.Equals("Deposit", StringComparison.OrdinalIgnoreCase);
        }
    }
}
