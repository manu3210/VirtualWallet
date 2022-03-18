using VirtualWallet.Models;

namespace VirtualWallet.Interfaces
{
    public interface IAccountService : IService<Account>
    {
        string Transfer(int fromId, int toId, double amount);
        string AddMoney(int idAccount, double amount, string cardNumber, int monthExp, int yearExp);
    }
}
