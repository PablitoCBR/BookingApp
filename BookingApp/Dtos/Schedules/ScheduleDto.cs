using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Dtos.Schedules
{
    public class ScheduleDto
    {
        public WorkingHours Monday { get; set; }
        public WorkingHours Tuesday { get; set; }
        public WorkingHours Wednesday { get; set; }
        public WorkingHours Thursday { get; set; }
        public WorkingHours Friday { get; set; }
        public WorkingHours Saturday { get; set; }
        public WorkingHours Sunday { get; set; }
    }
    public class WorkingHours
    {
        public TimeSpan Opening { get; set; }
        public TimeSpan Closeing { get; set; }
    }
}
