using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
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

        public override async Task<Account> GetAsync(int id)
        {
            return await _context.Accounts.Where(c => c.Id == id).Include(m => m.MovementsList).FirstOrDefaultAsync();
        }

        public async Task <string> TransferAsync(Account from, Account to, double amount)
        {
            string msj = "";

            from.Balance -= amount;
            to.Balance += amount;

            await UpdateAsync(from.Id, from);
            await UpdateAsync(to.Id, to);

            msj = "Successful operation";

            return msj;
        }

        public async Task<string> AddMoneyAsync(Account account, double amount)
        {
            string msj = "";

            account.Balance += amount;

            await UpdateAsync(account.Id, account);

            msj = "Successful operation";

            return msj;
        }

    }
}
