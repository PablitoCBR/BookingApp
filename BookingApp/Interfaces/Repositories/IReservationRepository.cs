using BookingApp.Entities.Schedules;
using System.Collections.Generic;

namespace BookingApp.Interfaces.Repositories
{
    public interface IReservationRepository
    {
        void Add(Reservation reservation);
        void Remove(int id);
        ICollection<Reservation> Get(int userId);
        void Confirm(int id);
        bool CheckIfExist(int id);
    }
}
