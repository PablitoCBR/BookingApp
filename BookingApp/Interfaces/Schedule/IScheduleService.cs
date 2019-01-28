using System.Collections.Generic;
using BookingApp.Dtos.Schedules;

namespace BookingApp.Interfaces.Schedule
{
    public interface IScheduleService
    {
        void AddSchedule(int userId, IList<ScheduleDto> schedule);
        void UpdateSchedule(int userId, IList<ScheduleDto> schedule);
        IList<ScheduleDto> GetSchedule(int userId);
        void RemoveSchedule(int userId);
    }
}
