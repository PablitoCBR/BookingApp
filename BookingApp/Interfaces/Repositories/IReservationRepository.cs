using BookingApp.Entities.Reservations;
using System.Collections.Generic;

namespace BookingApp.Interfaces.Repositories
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        ICollection<Reservation> GetPrevious(int id, string role);
        ICollection<Reservation> GetCurrent(int id, string role);
        bool CheckIfAvalible(Reservation reservation);
    }
}
