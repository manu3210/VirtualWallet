using Microsoft.EntityFrameworkCore;
using System.Linq;
using VirtualWallet.Interfaces;
using VirtualWallet.Models;

namespace VirtualWallet.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(WalletContext context) : base(context) { }

        protected override void UpdateData(Account toUpdate, Account element)
        {
            toUpdate.Id = element.Id;
            toUpdate.Balance = element.Balance;
            toUpdate.MovementsList = element.MovementsList;
            toUpdate.Name = element.Name;
            toUpdate.Type = element.Type;
            toUpdate.UserId = element.UserId;
        }

        public override Account Get(int id)
        {
            return _context.Accounts.Where(c => c.Id == id).Include(m => m.MovementsList).FirstOrDefault();
        }

        public string Transfer(Account from, Account to, double amount)
        {
            string msj = "";

            from.Balance -= amount;
            to.Balance += amount;

            Update(from.Id, from);
            Update(to.Id, to);

            msj = "Successful operation";

            return msj;
        }

        public string AddMoney(Account account, double amount)
        {
            string msj = "";

            account.Balance += amount;

            Update(account.Id, account);

            msj = "Successful operation";

            return msj;
        }

    }
}
