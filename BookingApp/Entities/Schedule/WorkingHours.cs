using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Entities.Schedule
{
    [Owned]
    [ComplexType]
    public class WorkingHours
    {
        public Time Opening { get; set; }
        public Time Closeing { get; set; }
    }
}
