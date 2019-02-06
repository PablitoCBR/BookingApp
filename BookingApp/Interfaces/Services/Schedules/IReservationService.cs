using BookingApp.Dtos.Schedules;
using BookingApp.Entities.Schedules;
using System.Collections.Generic;

namespace BookingApp.Interfaces.Services.Schedules
{
    public interface IReservationService
    {
        void MakeReservation(int userId, ReservationDto reservation);
        void CancelReservation(int id);
        ICollection<Reservation> GetReservations(int userId);
        void ConfirmReservation(int id);
    }
}
