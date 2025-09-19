using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewBankProject.Models
{
    public class AuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LogId { get; set; }

        public long AccountId { get; set; }
        public long UserId { get; set; }

        [Required]
        public string Action { get; set; }  

        public string Details { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
