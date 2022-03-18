using VirtualWallet.Models;

namespace VirtualWallet.Interfaces
{
    public interface IAccountRepository : IDataProcessing<Account>
    {
        string Transfer(Account from, Account to, double amount);
        string AddMoney(Account account, double amount);
    }
}
