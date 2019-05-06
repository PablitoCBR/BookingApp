using Microsoft.EntityFrameworkCore;
using BookingApp.Entities.Accounts;
using BookingApp.Entities.Schedules;
using BookingApp.Entities.Reservations;

namespace BookingApp.Contextes
{
    public class BookingAppContext : DbContext
    {
        public BookingAppContext(DbContextOptions<BookingAppContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
