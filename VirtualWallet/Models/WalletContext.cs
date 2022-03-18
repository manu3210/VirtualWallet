using Microsoft.EntityFrameworkCore;

namespace VirtualWallet.Models
{
    public class WalletContext : DbContext
    {
        public WalletContext(DbContextOptions<WalletContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Movements> Movements { get; set; }
    }
}
