using BookingApp.Entities.Schedules;
using BookingApp.Interfaces.Repositories;
using BookingApp.Contextes;
using System.Linq;

namespace BookingApp.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly SchedulesContext _context;

        public ScheduleRepository(SchedulesContext context)
        {
            _context = context;
        }

        public void Add(Schedule data)
        {
            _context.Schedules.Add(data);
            _context.SaveChanges();
        }

        public void Remove(Schedule data)
        {
            _context.Schedules.Remove(data);
            _context.SaveChanges();
        }

        public void Update(Schedule data)
        {
            _context.Schedules.Update(data);
            _context.SaveChanges();
        }

        public bool CheckIfExist(int id) => _context.Schedules.Any(x => x.BusinessId == id);

        public Schedule Get(int id) => _context.Schedules.SingleOrDefault(x => x.BusinessId == id);
    }
}
