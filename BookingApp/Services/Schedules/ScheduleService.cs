using System.Collections.Generic;
using System;
using BookingApp.Dtos.Schedules;
using BookingApp.Interfaces.Services.Schedules;
using BookingApp.Contextes.Schedules;
using BookingApp.Helpers;
using BookingApp.Entities.Schedules;
using System.Linq;
using AutoMapper;

namespace BookingApp.Services.Schedules
{
    public class ScheduleService : IScheduleService
    {
        private readonly ScheduleContext _scheduleContext;
        private readonly IMapper _mapper;

        public ScheduleService(ScheduleContext scheduleContext, IMapper mapper)
        {
            _scheduleContext = scheduleContext;
            _mapper = mapper;
        }

        public void AddSchedule(int userId, IList<ScheduleDto> weekSchedule)
        {
            if (weekSchedule.Count != 7)
                throw new AppException("Schedule is not valid:  provide schedule for every day of week");

            if (_scheduleContext.Schedules.Any(x => x.UserId == userId))
                throw new AppException("Schedule for that user already exist!");

            foreach (ScheduleDto schedule in weekSchedule)
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
                catch (Exception ex)
                {
                    throw new AppException(ex.Message, schedule);
                }
            }
            _scheduleContext.SaveChanges();
        }

        public IList<ScheduleDto> GetWeekSchedule(int userId)
        {

            List<Schedule> weekSchedule = _scheduleContext.Schedules.Where(x => x.UserId == userId).ToList();
            
            //Check if schedule was found
            if (weekSchedule.Count == 0)
                throw new AppException($"Schedule for id = {userId} not found!");

            List<ScheduleDto> weekScheduleDto = _mapper.Map<List<Schedule>, List<ScheduleDto>>(weekSchedule);
            return weekScheduleDto;
        }

        public void RemoveSchedule(int userId)
        {
            //Check if schedule for user exist
            if (!_scheduleContext.Schedules.Any(x => x.UserId == userId))
                throw new AppException("Schedule for user not exist!");

            _scheduleContext.Schedules.RemoveRange(
                _scheduleContext.Schedules.Where(x => x.UserId == userId)
                .ToArray()
             );
            _scheduleContext.SaveChanges();
        }

        public void UpdateSchedule(int userId, List<ScheduleDto> schedules)
        {
            if (schedules == null || schedules.Count == 0)
                throw new ArgumentException();

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
