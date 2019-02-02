using BookingApp.Dtos.Schedules;
using System.Collections.Generic;
using BookingApp.Entities.Schedules;

namespace BookingApp.Interfaces.Repositories
{
    public interface IScheduleRepository
    {
        bool CheckIfExist(int userId);
        void Add(int userId, IList<ScheduleDto> weekSchedule);
        List<Schedule> Get(int userId);
        void Remove(int UserId);
        void Update(int userId, List<ScheduleDto> schedules);
    }
}
