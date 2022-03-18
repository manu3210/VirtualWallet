using System;

namespace VirtualWallet.Models
{
    public class Movements : BaseModel
    {
        public DateTime Date { get; set; }
        public string Detail { get; set; }
        public double Amount { get; set; }
        public string remarks { get; set; }
        public int AccountId { get; set; }
    }
}
