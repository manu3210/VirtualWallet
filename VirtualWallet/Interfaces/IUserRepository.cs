using System.Threading.Tasks;
using VirtualWallet.DTO;
using VirtualWallet.Models;

namespace VirtualWallet.Interfaces
{
    public interface IUserRepository : IDataProcessing<User>
    {
        Task<UserDto> GetForLoginAsync(string email, string password);
    }
}
