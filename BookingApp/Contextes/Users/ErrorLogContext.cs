using Microsoft.EntityFrameworkCore;
using BookingApp.Entities.Users;

namespace BookingApp.Contextes.Users
{
    public class ErrorLogContext : DbContext
    {
        public ErrorLogContext(DbContextOptions<ErrorLogContext> options) : base(options) { }

        public DbSet<PasswordExceptionLog> PasswordExceptionLogs { get; set; }
    }
}
