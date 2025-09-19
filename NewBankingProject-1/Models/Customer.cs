using System;
using System.Collections.Generic;

namespace NewBankingProject_1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CRN { get; set; }
        public DateTime? LastLogin { get; set; }
        public string AccountNumber { get; set; }

       
        public ICollection<Account> Accounts { get; set; }
    }
}
