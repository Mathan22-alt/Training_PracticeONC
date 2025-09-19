using System.Collections.Generic;

namespace NewBankingProject_1.Models.Dtos
{
    public class AccountStatementDto
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public List<StatementLineDto> Lines { get; set; }
    }
}
