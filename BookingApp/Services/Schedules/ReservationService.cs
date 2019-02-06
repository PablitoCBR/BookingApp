using System.Collections.Generic;
using BookingApp.Dtos.Schedules;
using BookingApp.Entities.Schedules;
using BookingApp.Interfaces.Services.Schedules;
using BookingApp.Interfaces.Repositories;
using BookingApp.Helpers;
using System;
using AutoMapper;

namespace BookingApp.Services.Schedules
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, 
            IUserRepository userRepository, IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public void CancelReservation(int id)
        {
            if (_reservationRepository.CheckIfExist(id))
                _reservationRepository.Remove(id);
            else throw new AppException("Reservation not found");
        }

        public void ConfirmReservation(int id)
        {
            if (_reservationRepository.CheckIfExist(id))
                _reservationRepository.Confirm(id);
            else throw new AppException("Reservation not found");
        }

        public ICollection<Reservation> GetReservations(int userId)
        {
            if (_userRepository.CheckIfExistById(userId))
                return _reservationRepository.Get(userId);

            throw new AppException($"User with id: {userId} not exist");       
        }

        public void MakeReservation(int userId, ReservationDto reservation)
        {
            if (reservation.DurationOfServiceMinutes == 0)
                throw new AppException("Invalid duration of service");

            if (string.IsNullOrWhiteSpace(reservation.ServiceType))
                throw new AppException("Invalid service type");

            Schedule schedule = _scheduleRepository.GetDaySchedule(userId, (int)reservation.Date.DayOfWeek);

            if (schedule == null)
                throw new AppException("Schedule of company not found!");

            if (reservation.Date.Hour < ((TimeSpan)schedule.Opening).Hours || reservation.Date.Hour > ((TimeSpan)schedule.Closeing).Hours
                || schedule.Opening == null || schedule.Closeing == null)
                throw new AppException("Reservation date not match working hours");

            reservation.Confirmed = false;
            Reservation reservationEntity = _mapper.Map<Reservation>(reservation);
            reservationEntity.UserId = userId;

            _reservationRepository.Add(reservationEntity);
        }
    }
}
