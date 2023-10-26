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
    }
}