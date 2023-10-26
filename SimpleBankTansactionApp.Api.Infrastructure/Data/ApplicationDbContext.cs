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

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankTransaction>()
                .HasOne(bt => bt.IncomingBankAccount)
                .WithMany(ba => ba.IncomingBankTransactions)
                .HasForeignKey(bt => bt.IncomingBankAccountId);
            modelBuilder.Entity<BankTransaction>()
                .HasOne(bt => bt.OutgoingBankAccount)
                .WithMany(ba => ba.OutgoingBankTransactions)
                .HasForeignKey(bt => bt.OutgoingBankAccountId);

        }
    }
}