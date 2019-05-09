using BookingApp.Contextes;
using BookingApp.Entities.Accounts;
using BookingApp.Entities.Reservations;
using BookingApp.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly BookingAppContext _context;

        public ReservationRepository(BookingAppContext context)
        {
            _context = context;
        }

        public void Add(Reservation data)
        {
            _context.Reservations.Add(data);
            _context.SaveChanges();
        }

        public bool CheckIfAvalible(Reservation reservation)
        {
            return !_context.Reservations.Any(x => x.Date >= reservation.Date && x.Date.AddMinutes(x.Duration) <= reservation.Date.AddMinutes(reservation.Duration));
        }

        public Reservation Get(int id) 
            => _context.Reservations.SingleOrDefault(x => x.Id == id);


        public ICollection<Reservation> GetCurrent(int id, string role)
        {
            if(role == Role.User)
               return  _context.Reservations.Where(x => x.Date >= DateTime.Now && x.UserId == id).ToList();
            else return _context.Reservations.Where(x => x.Date >= DateTime.Now && x.BusinessId == id).ToList();
        }

        public ICollection<Reservation> GetPrevious(int id, string role)
        {
            if (role == Role.User)
                return _context.Reservations.Where(x => x.Date < DateTime.Now && x.UserId == id).ToList();
            else return _context.Reservations.Where(x => x.Date < DateTime.Now && x.BusinessId == id).ToList();
        }

        public void Remove(Reservation data)
        {
            _context.Reservations.Remove(data);
            _context.SaveChanges();
        }

        public void Update(Reservation data)
        {
            _context.Reservations.Update(data);
            _context.SaveChanges();
        }
    }
}
