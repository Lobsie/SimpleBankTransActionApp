using SimpleBankTransactionApp.Core.Entities.BankAccounts;
using SimpleBankTransactionApp.Core.Entities.Base;

namespace SimpleBankTransactionApp.Core.Entities.BankTransactions
{
    public class BankTransaction : EntityBase
    {
        public Guid OutgoingBankAccountId { get; set; }
        public BankAccount OutgoingBankAccount  { get; set; }
        public Guid IncomingBankAccountId { get; set; }
        public BankAccount IncomingBankAccount { get; set; }
        public decimal Amount { get; set; }
    }
}