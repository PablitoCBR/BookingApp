using BookingApp.Dtos.Schedules;
using BookingApp.Interfaces.Services.Schedules;
using BookingApp.Interfaces.Repositories;
using BookingApp.Entities.Schedules;
using BookingApp.Exceptions;
using AutoMapper;

namespace BookingApp.Services.Schedules
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;
        private readonly ScheduleValidator _scheduleValidator;

        public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper, ScheduleValidator scheduleValidator)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
            _scheduleValidator = scheduleValidator;
        }

        public void Create(int id, ScheduleDto scheduleDto)
        {
            if (_scheduleRepository.CheckIfExist(id))
                throw new ValidationException("Schedule already exist");
            if (!_scheduleValidator.VerifySchedule(scheduleDto))
                throw new ValidationException("Invalid schedule format", scheduleDto);

            Schedule schedule = _mapper.Map<Schedule>(scheduleDto);
            schedule.BusinessId = id;
            _scheduleRepository.Add(schedule);
        }

        public ScheduleDto Get(int id)
        {
            Schedule schedule = _scheduleRepository.Get(id);
            if (schedule == null)
                throw new ValidationException("Schedule not found!");
            else return _mapper.Map<ScheduleDto>(schedule);
        }

        public void Remove(int id)
        {
            Schedule schedule = _scheduleRepository.Get(id);
            if (schedule == null)
                throw new ValidationException("Schedule not found!");
            else _scheduleRepository.Remove(schedule);
        }

        public void Update(int id, ScheduleDto scheduleDto)
        {
            if (!_scheduleValidator.VerifySchedule(scheduleDto))
                throw new ValidationException("Invalid schedule format", scheduleDto);

            Schedule schedule = _mapper.Map<Schedule>(scheduleDto);
            schedule.BusinessId = id;
            _scheduleRepository.Update(schedule);
        }
    }
}
