using Microsoft.AspNetCore.Mvc;
using NewBankProject.Data;
using NewBankProject.Models;

namespace NewBankProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly BankingContext _context;

        public TransactionsController(BankingContext context)
        {
            _context = context;
        }

       
        [HttpPost("Add")]
        public IActionResult AddTransaction([FromBody] Transaction transaction)
        {
            if (transaction == null)
                return BadRequest("Transaction data is required.");

            var account = _context.Accounts.FirstOrDefault(a => a.AccountId == transaction.AccountId);
            if (account == null)
                return NotFound("Account not found.");

          
            if (transaction.Type == "CREDIT")
                account.CurrentBalance += transaction.Amount;
            else if (transaction.Type == "DEBIT")
                account.CurrentBalance -= transaction.Amount;

            transaction.BalanceAfter = account.CurrentBalance;

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return Ok(transaction);
        }

       
        [HttpGet]
        public IActionResult GetTransactions()
        {
            return Ok(_context.Transactions.ToList());
        }


        [HttpGet("Search")]
        public IActionResult SearchTransactions(int accountId, DateOnly start, DateOnly end)
        {
            if (start > end)
                return BadRequest("Start date cannot be later than end date.");

            var startDate = start.ToDateTime(TimeOnly.MinValue);  
            var endDate = end.ToDateTime(TimeOnly.MaxValue);      

            var transactions = _context.Transactions
                .Where(t => t.AccountId == accountId && t.TxnDate >= startDate && t.TxnDate <= endDate)
                .OrderByDescending(t => t.TxnDate)
                .Select(t => new
                {
                    t.TxnId,
                    t.Type,
                    t.Amount,
                    t.BalanceAfter,
                    TxnDate = t.TxnDate.ToString("yyyy-MM-dd HH:mm")
                })
                .ToList();

            return Ok(transactions);
        }

    }
}
