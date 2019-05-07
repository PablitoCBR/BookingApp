using BookingApp.Dtos.Reservations;
using BookingApp.Entities.Reservations;
using System.Collections.Generic;

namespace BookingApp.Interfaces.Services
{
    public interface IReservationService
    {
        void AddReservation(ReservationDto reservationDto, int userId);
        void CancelReservation(int reservationId);
        Reservation GetReservation(int Id);
        ICollection<Reservation> GetReservations(int id, string role);
        ICollection<Reservation> GetOldReservations(int id, string role);
        void ConfirmReservation(int id);
    }
}
