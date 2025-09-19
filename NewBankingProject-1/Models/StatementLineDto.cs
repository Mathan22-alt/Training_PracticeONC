using System;

namespace NewBankingProject_1.Models.Dtos
{
    public class StatementLineDto
    {
        public DateTime Date { get; set; }
        public decimal? Debit { get; set; }      
        public decimal? Credit { get; set; }   
        public string Description { get; set; }
        public decimal Balance { get; set; }    
        public string Type { get; set; }
    }
}
