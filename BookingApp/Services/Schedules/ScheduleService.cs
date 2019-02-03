using System.Collections.Generic;
using System;
using BookingApp.Dtos.Schedules;
using BookingApp.Interfaces.Services.Schedules;
using BookingApp.Helpers;
using BookingApp.Entities.Schedules;
using BookingApp.Interfaces.Repositories;
using AutoMapper;

namespace BookingApp.Services.Schedules
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ScheduleService(IScheduleRepository scheduleRepository, IUserRepository  userRepository,IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void AddSchedule(int userId, IList<ScheduleDto> weekSchedule)
        {
            if (weekSchedule.Count != 7)
                throw new AppException("Schedule is not valid:  provide schedule for every day of week");

            if (!_userRepository.CheckIfExistById(userId))
                throw new AppException("User with that id does not exist!");

            if (_scheduleRepository.CheckIfExist(userId))
                throw new AppException("Schedule for that user already exist!");

            _scheduleRepository.Add(userId, weekSchedule);
        }

        public IList<ScheduleDto> GetWeekSchedule(int userId)
        {

            List<Schedule> weekSchedule = _scheduleRepository.Get(userId);
            
            //Check if schedule was found
            if (weekSchedule.Count == 0)
                throw new AppException($"Schedule for id = {userId} not found!");

            List<ScheduleDto> weekScheduleDto = _mapper.Map<List<Schedule>, List<ScheduleDto>>(weekSchedule);
            return weekScheduleDto;
        }

        public void RemoveSchedule(int userId)
        {
            //Check if schedule for user exist
            if (!_scheduleRepository.CheckIfExist(userId))
                throw new AppException("Schedule for user not exist!");
            _scheduleRepository.Remove(userId);   
        }

        public void UpdateSchedule(int userId, List<ScheduleDto> schedules)
        {
            if (schedules == null || schedules.Count == 0)
                throw new ArgumentException("No data provided!");

            _scheduleRepository.Update(userId, schedules);
        }
    }
}
