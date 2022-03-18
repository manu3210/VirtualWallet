using System.Threading.Tasks;
using VirtualWallet.Models;

namespace VirtualWallet.Interfaces
{
    public interface IUserRepository : IDataProcessing<User>
    {
        Task<User> GetForLoginAsync(string email, string password);
    }
}
