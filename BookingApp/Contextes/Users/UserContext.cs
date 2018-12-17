using Microsoft.EntityFrameworkCore;
using BookingApp.Entities.Users;

namespace BookingApp.Contextes.Users
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
