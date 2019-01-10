using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Dtos.Schedules
{
    public class ReservationDto
    {
        public DateTime Date { get; set; }
        public int DurationOfServiceMinutes { get; set; }
        public string ServiceType { get; set; }
        public string OptionalDescription { get; set; }
    }
}
