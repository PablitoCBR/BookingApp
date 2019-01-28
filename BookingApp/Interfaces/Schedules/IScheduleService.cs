using System.Collections.Generic;
using BookingApp.Dtos.Schedules;

namespace BookingApp.Interfaces.Schedules
{
    public interface IScheduleService
    {
        void AddSchedule(int userId, IList<ScheduleDto> weekSchedule);
        void UpdateSchedule(int userId, IList<ScheduleDto> weekSchedule);
        IList<ScheduleDto> GetWeekSchedule(int userId);
        void RemoveSchedule(int userId);
    }
}
