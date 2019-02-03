using System;

namespace BookingApp.Dtos.Schedules
{
    public class ReservationDto
    {
        public DateTime Date { get; set; }
        public int DurationOfServiceMinutes { get; set; }
        public string ServiceType { get; set; }
        public string OptionalDescription { get; set; }
        public bool Confirmed { get; set; }
    }
}
