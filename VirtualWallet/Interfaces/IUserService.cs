using VirtualWallet.Models;

namespace VirtualWallet.Interfaces
{
    public interface IUserService : IService<User>
    {
        public User GetForLogin(string email, string password);
    }
}
