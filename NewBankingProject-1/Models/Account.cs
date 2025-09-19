using System.Collections.Generic;

namespace NewBankingProject_1.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string BranchName { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

       
        public Customer Customer { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
