using BookingApp.Entities.Schedules;

namespace BookingApp.Interfaces.Repositories
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        bool CheckIfExist(int id);
    }
}
