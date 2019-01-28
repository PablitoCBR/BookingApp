using System.Collections.Generic;
using BookingApp.Dtos.Schedules;
using BookingApp.Interfaces.Schedule;

namespace BookingApp.Services.Schedule
{
    public class ScheduleService : IScheduleService
    {
        public void AddSchedule(int userId, IList<ScheduleDto> schedule)
        {
            throw new System.NotImplementedException();
        }

        public IList<ScheduleDto> GetSchedule(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveSchedule(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateSchedule(int userId, IList<ScheduleDto> schedule)
        {
            throw new System.NotImplementedException();
        }
    }
}
