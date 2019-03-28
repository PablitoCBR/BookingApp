using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Entities.Schedules
{
    [Owned]
    [ComplexType]
    public class WorkingHours
    {
        public Time Opening { get; set; }
        public Time Closing { get; set; }
    }
}
