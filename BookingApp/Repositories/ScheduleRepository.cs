using System.Collections.Generic;
using BookingApp.Dtos.Schedules;
using BookingApp.Interfaces.Repositories;
using BookingApp.Contextes.Schedules;
using BookingApp.Entities.Schedules;
using System.Linq;

namespace BookingApp.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ScheduleContext _scheduleContext;
        public ScheduleRepository(ScheduleContext context)
        {
            _scheduleContext = context;
        }

        public void Add(int userId, IList<ScheduleDto> weekSchedule)
        {
            foreach (ScheduleDto schedule in weekSchedule)
            {
                Schedule daySchedule = new Schedule()
                {
                    UserId = userId,
                    Day = schedule.Day,
                    Opening = schedule.Opening,
                    Closeing = schedule.Closeing
                };
                _scheduleContext.Schedules.Add(daySchedule);
            }
            _scheduleContext.SaveChanges();
        }

        public bool CheckIfExist(int userId)
        {
            return _scheduleContext.Schedules.Any(x => x.UserId == userId);
        }

        public List<Schedule> Get(int userId)
        {
            return _scheduleContext.Schedules.Where(x => x.UserId == userId).ToList();
        }

        public void Remove(int userId)
        {
            _scheduleContext.Schedules.RemoveRange(
                _scheduleContext.Schedules.Where(x => x.UserId == userId)
                .ToArray()
             );
            _scheduleContext.SaveChanges();
        }

        public void Update(int userId, List<ScheduleDto> schedules)
        {
            var schedulesToUpdate = _scheduleContext.Schedules
                 .Where(x => x.UserId == userId && schedules.Exists(y => y.Day == x.Day))
                .ToList();
            schedulesToUpdate.ForEach(schedule =>
            {
                schedule.Opening = schedules.FirstOrDefault(x => x.Day == schedule.Day).Opening;
                schedule.Closeing = schedules.FirstOrDefault(x => x.Day == schedule.Day).Closeing;
            });
            _scheduleContext.SaveChanges();
        }
    }
}
