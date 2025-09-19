using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewBankProject.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AccountId { get; set; }

        public long CustomerId { get; set; }

        [Required, MaxLength(30)]
        public string AccountNumber { get; set; }

        [Required, MaxLength(20)]
        public string AccountType { get; set; }

        public decimal CurrentBalance { get; set; } = 0.00M;

        public ICollection<Transaction> Transactions { get; set; }
    }
}
