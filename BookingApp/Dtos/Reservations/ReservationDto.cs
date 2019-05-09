using System;

namespace BookingApp.Dtos.Reservations
{
    public class ReservationDto
    {
        public int BusinessId { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public bool Confirmed { get; set; }
    }
}
