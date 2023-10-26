using Microsoft.EntityFrameworkCore;
using SimpleBankTransactionApp.Core.Entities.BankAccounts;
using SimpleBankTransactionApp.Core.Entities.BankTransactions;
using SimpleBankTransactionApp.Core.Entities.Clients;

namespace SimpleBankTansactionApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankTransaction>()
                .HasOne(bt => bt.IncomingBankAccount)
                .WithMany(ba => ba.IncomingBankTransactions)
                .HasForeignKey(bt => bt.IncomingBankAccountId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BankTransaction>()
                .HasOne(bt => bt.OutgoingBankAccount)
                .WithMany(ba => ba.OutgoingBankTransactions)
                .HasForeignKey(bt => bt.OutgoingBankAccountId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BankTransaction>()
                .Property(bt => bt.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<BankAccount>()
                .Property(ba => ba.Balance)
                .HasPrecision(18, 2);
        }
    }
}