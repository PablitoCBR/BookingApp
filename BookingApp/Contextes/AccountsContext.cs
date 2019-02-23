using Microsoft.EntityFrameworkCore;
using BookingApp.Entities.Accounts;

namespace BookingApp.Contextes
{
    public class AccountsContext : DbContext
    {
        public AccountsContext(DbContextOptions<AccountsContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
