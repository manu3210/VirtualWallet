using System.Collections.Generic;

namespace VirtualWallet.Models
{
    public class Account : BaseModel
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public double Balance { get; set; }
        public int UserId { get; set; }
        public List<Movements> MovementsList { get; set; }
    }
}
