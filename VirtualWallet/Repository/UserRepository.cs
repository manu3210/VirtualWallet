using System.Linq;
using VirtualWallet.Interfaces;
using VirtualWallet.Models;

namespace VirtualWallet.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(WalletContext context) : base(context) { }

        protected override void UpdateData(User toUpdate, User element)
        {
            toUpdate.Id = element.Id;
            toUpdate.FirstName = element.FirstName;
            toUpdate.LastName = element.LastName;
            toUpdate.Dni = element.Dni;
            toUpdate.AccountList = element.AccountList;
            toUpdate.DateOfBirth = element.DateOfBirth;
            toUpdate.Email = element.Email;
            toUpdate.Password = element.Password;
            toUpdate.UserName = element.UserName;
        }

        public User GetForLogin(string email, string password)
        {
            return _context.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
        }
    }
}
