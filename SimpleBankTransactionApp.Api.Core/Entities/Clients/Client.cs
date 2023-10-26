using SimpleBankTransactionApp.Core.Entities.BankAccounts;
using SimpleBankTransactionApp.Core.Entities.Base;

namespace SimpleBankTransactionApp.Core.Entities.Clients
{
    public class Client : EntityBase
    {
        public string Name { get; set; }
        public ICollection<BankAccount> BankAccounts { get; set; }
    }
}