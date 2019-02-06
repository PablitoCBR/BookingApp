using System.Collections.Generic;
using BookingApp.Entities.Schedules;
using BookingApp.Interfaces.Repositories;
using BookingApp.Contextes;
using System.Linq;

namespace BookingApp.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ScheduleContext _scheduleContext;

        public ReservationRepository(ScheduleContext scheduleContext)
        {
            _scheduleContext = scheduleContext;
        }

        public void Add(Reservation reservation)
        {
            _scheduleContext.Reservations.Add(reservation);
            _scheduleContext.SaveChanges();
        }

        public bool CheckIfExist(int id)
        {
            return _scheduleContext.Reservations.Any(x => x.Id == id);
        }

        public void Confirm(int id)
        {
            _scheduleContext.Reservations.SingleOrDefault(x => x.Id == id).Confirmed = true;
            _scheduleContext.SaveChanges();
        }

        public ICollection<Reservation> Get(int userId)
        {
            return _scheduleContext.Reservations.Where(x => x.UserId == userId).ToList();
        }

        public void Remove(int id)
        {
            _scheduleContext.Reservations.Remove(
                _scheduleContext.Reservations.SingleOrDefault(x => x.Id == id)
                );
            _scheduleContext.SaveChanges();
        }
    }
}
