using Microsoft.EntityFrameworkCore;
using BookingApp.Entities.Schedule;

namespace BookingApp.Contextes
{
    public class SchedulesContext : DbContext
    {
        public SchedulesContext(DbContextOptions<SchedulesContext> options) : base(options) { }

        public DbSet<Schedule> Schedules { get; set; }
    }
}
