using Microsoft.EntityFrameworkCore;
using BookingApp.Entities.Users;

namespace BookingApp.Contextes
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
