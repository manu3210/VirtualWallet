using System.Threading.Tasks;
using VirtualWallet.Models;

namespace VirtualWallet.Interfaces
{
    public interface IAccountService : IService<Account>
    {
        Task<string> Transfer(int fromId, int toId, double amount);
        Task<string> AddMoney(int idAccount, double amount, string cardNumber, int monthExp, int yearExp);
    }
}
