using Microsoft.EntityFrameworkCore;
using BookingApp.Entities.Schedules;

namespace BookingApp.Contextes.Schedules
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options) { }

        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
