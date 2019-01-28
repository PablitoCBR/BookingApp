using System.Collections.Generic;
using System;
using BookingApp.Dtos.Schedules;
using BookingApp.Interfaces.Schedules;
using BookingApp.Contextes.Schedules;
using BookingApp.Helpers;
using BookingApp.Entities.Schedules;
using System.Linq;

namespace BookingApp.Services.Schedules
{
    public class ScheduleService : IScheduleService
    {
        private readonly ScheduleContext _scheduleContext;

        public ScheduleService(ScheduleContext scheduleContext)
        {
            _scheduleContext = scheduleContext;
        }

        public void AddSchedule(int userId, IList<ScheduleDto> weekSchedule)
        {
            if (weekSchedule.Count != 7)
                throw new AppException("Schedule is not valid:  provide schedule for every day of week");

            if (_scheduleContext.Schedules.Any(x => x.UserId == userId))
                throw new AppException("Schedule for that user already exist!");

            foreach(ScheduleDto schedule in weekSchedule)
            {
                try
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
                catch (ArgumentNullException ex)
                {
                    throw new AppException(ex.Message, schedule);
                }         
            }
            _scheduleContext.SaveChanges();
        }

        public IList<ScheduleDto> GetWeekSchedule(int userId)
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
