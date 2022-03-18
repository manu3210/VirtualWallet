using VirtualWallet.Interfaces;
using VirtualWallet.Models;

namespace VirtualWallet.Repository
{
    public class MovementRepository : Repository<Movements>, IMovementRepository
    {
        public MovementRepository(WalletContext context) : base(context) { }

        protected override void UpdateData(Movements toUpdate, Movements element)
        {
            toUpdate.Id = element.Id;
            toUpdate.AccountId = element.AccountId;
            toUpdate.Amount = element.Amount;
            toUpdate.Date = element.Date;
            toUpdate.Detail = element.Detail;
            toUpdate.remarks = element.remarks;
        }
    }
}
