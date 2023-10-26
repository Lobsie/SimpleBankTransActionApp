using SimpleBankTransactionApp.Core.Entities.BankTransactions;
using SimpleBankTransactionApp.Core.Entities.Base;
using SimpleBankTransactionApp.Core.Entities.Clients;

namespace SimpleBankTransactionApp.Core.Entities.BankAccounts
{
    public class BankAccount : EntityBase
    {
        public decimal Balance { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public ICollection<BankTransaction> OutgoingBankTransactions { get; set; }
        public ICollection<BankTransaction> IncomingBankTransactions { get; set; }
    }
}