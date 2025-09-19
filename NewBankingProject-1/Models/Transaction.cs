using System;

namespace NewBankingProject_1.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }    
        public string Type { get; set; }       
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
