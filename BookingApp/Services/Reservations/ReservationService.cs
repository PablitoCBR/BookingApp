using AutoMapper;
using BookingApp.Dtos.Reservations;
using BookingApp.Entities.Accounts;
using BookingApp.Entities.Reservations;
using BookingApp.Entities.Schedules;
using BookingApp.Exceptions;
using BookingApp.Interfaces.Repositories;
using BookingApp.Interfaces.Services;
using System;
using System.Collections.Generic;


namespace BookingApp.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly IScheduleRepository _scheduleRepository;

        public ReservationService(IMapper mapper, IReservationRepository reservationRepository, IScheduleRepository scheduleRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _scheduleRepository = scheduleRepository;
        }

        public void AddReservation(ReservationDto reservationDto, int userId)
        {
            Reservation reservation = _mapper.Map<Reservation>(reservationDto);

            if (reservation.Date < DateTime.Now)
                throw new ValidationException("Reservation date cannot be before current");

            if (!_reservationRepository.CheckIfAvalible(reservation))
                throw new ValidationException("Given date is not avalible");

            if (!ValidateReservation(reservation))
                throw new ValidationException("Unavalible at given day");

            reservation.UserId = userId;
            reservation.Confirmed = false;
            _reservationRepository.Add(reservation);
        }

        public void CancelReservation(int reservationId)
            => _reservationRepository.Remove(_reservationRepository.Get(reservationId));

        public void ConfirmReservation(int id)
        {
            Reservation reservation = _reservationRepository.Get(id);
            reservation.Confirmed = true;
            _reservationRepository.Update(reservation);
        }

        public ICollection<Reservation> GetOldReservations(int id, string role)
            => _reservationRepository.GetPrevious(id, role);

        public Reservation GetReservation(int id)
            => _reservationRepository.Get(id);

        public ICollection<Reservation> GetReservations(int id, string role)
            => _reservationRepository.GetCurrent(id, role);

        private bool ValidateReservation(Reservation reservation)
        {

            Schedule schedule = _scheduleRepository.Get(reservation.BusinessId);
            DayOfWeek dayOfWeek = reservation.Date.DayOfWeek;

            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    if (schedule.Sunday.Opening.CompareTo(reservation.Date) == -1
                        || schedule.Sunday.Closing.CompareTo(reservation.Date.AddMinutes(reservation.Duration)) == 1)
                        return false;
                    else return true;
                case DayOfWeek.Monday:
                    if (schedule.Monday.Opening.CompareTo(reservation.Date) == -1
                        || schedule.Sunday.Closing.CompareTo(reservation.Date.AddMinutes(reservation.Duration)) == 1)
                        return false;
                    else return true;
                case DayOfWeek.Tuesday:
                    if (schedule.Tuesday.Opening.CompareTo(reservation.Date) == -1
                        || schedule.Tuesday.Closing.CompareTo(reservation.Date.AddMinutes(reservation.Duration)) == 1)
                        return false;
                    else return true;
                case DayOfWeek.Wednesday:
                    if (schedule.Wednesday.Opening.CompareTo(reservation.Date) == -1
                        || schedule.Wednesday.Closing.CompareTo(reservation.Date.AddMinutes(reservation.Duration)) == 1)
                        return false;
                    else return true;
                case DayOfWeek.Thursday:
                    if (schedule.Thursday.Opening.CompareTo(reservation.Date) == -1
                        || schedule.Thursday.Closing.CompareTo(reservation.Date.AddMinutes(reservation.Duration)) == 1)
                        return false;
                    else return true;
                case DayOfWeek.Friday:
                    if (schedule.Friday.Opening.CompareTo(reservation.Date) == -1
                        || schedule.Friday.Closing.CompareTo(reservation.Date.AddMinutes(reservation.Duration)) == 1)
                        return false;
                    else return true;
                case DayOfWeek.Saturday:
                    if (schedule.Saturday.Opening.CompareTo(reservation.Date) == -1
                        || schedule.Saturday.Closing.CompareTo(reservation.Date.AddMinutes(reservation.Duration)) == 1)
                        return false;
                    else return true;
                default:
                    return false;
            }
        }
    }
}
