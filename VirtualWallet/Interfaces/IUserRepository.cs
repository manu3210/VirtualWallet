using VirtualWallet.Models;

namespace VirtualWallet.Interfaces
{
    public interface IUserRepository : IDataProcessing<User>
    {
        public User GetForLogin(string email, string password);
    }
}
