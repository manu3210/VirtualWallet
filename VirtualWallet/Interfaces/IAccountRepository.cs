using System.Threading.Tasks;
using VirtualWallet.Models;

namespace VirtualWallet.Interfaces
{
    public interface IAccountRepository : IDataProcessing<Account>
    {
        Task<string> TransferAsync(Account from, Account to, double amount);
        Task<string> AddMoneyAsync(Account account, double amount);
    }
}
