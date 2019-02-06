using System.Collections.Generic;
using BookingApp.Dtos.Schedules;
using BookingApp.Entities.Schedules;
using BookingApp.Interfaces.Repositories;

namespace BookingAppxUnitTests.Reservations
{
    class TempScheduleRepository : IScheduleRepository
    {
        public void Add(int userId, IList<ScheduleDto> weekSchedule)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckIfExist(int userId)
        {
            throw new System.NotImplementedException();
        }

        public List<Schedule> Get(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Schedule GetDaySchedule(int userId, int day)
        {
            return new Schedule()
            {
                Id = 1,
                UserId = 1,
                Day = 1,
                Opening = new System.TimeSpan(00, 00, 00),
                Closeing = new System.TimeSpan(23, 00, 00)
            };
        }

        public void Remove(int UserId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int userId, List<ScheduleDto> schedules)
        {
            throw new System.NotImplementedException();
        }
    }
}
