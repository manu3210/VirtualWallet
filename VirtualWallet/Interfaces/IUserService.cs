using System.Threading.Tasks;
using VirtualWallet.DTO;
using VirtualWallet.Models;

namespace VirtualWallet.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<UserDto> GetForLogin(string email, string password);
    }
}
