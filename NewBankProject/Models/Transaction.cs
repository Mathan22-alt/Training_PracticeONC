using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewBankProject.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TxnId { get; set; }

        [ForeignKey("Account")]
        public long AccountId { get; set; }
        public Account Account { get; set; }

        public DateTime TxnDate { get; set; } = DateTime.Now;

        [Required]
        public string Type { get; set; } 

        public decimal Amount { get; set; }

        public string Narration { get; set; }

        public decimal BalanceAfter { get; set; }

        public string Reference { get; set; }

        public string Channel { get; set; }

        public string Status { get; set; } = "SUCCESS";
    }
}
