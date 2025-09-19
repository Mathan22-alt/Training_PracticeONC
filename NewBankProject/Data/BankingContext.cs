using Microsoft.EntityFrameworkCore;
using NewBankProject.Models;

namespace NewBankProject.Data
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Account>().ToTable("Accounts")
                .Property(a => a.CurrentBalance).HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>().ToTable("Transactions");
            modelBuilder.Entity<Transaction>().Property(t => t.Amount).HasPrecision(18, 2);
            modelBuilder.Entity<Transaction>().Property(t => t.BalanceAfter).HasPrecision(18, 2);

            modelBuilder.Entity<AuditLog>().ToTable("AuditLog");

            modelBuilder.Entity<Transaction>()
                .HasIndex(t => new { t.AccountId, t.TxnDate });
        }
    }
}
