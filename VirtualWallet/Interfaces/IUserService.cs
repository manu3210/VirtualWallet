using System.Threading.Tasks;
using VirtualWallet.Models;

namespace VirtualWallet.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<User> GetForLogin(string email, string password);
    }
}
