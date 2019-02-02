using System;


namespace BookingApp.Dtos.Schedules
{
    public class ScheduleDto
    {
        public int Day { get; set; }
        public TimeSpan? Opening { get; set; }
        public TimeSpan? Closeing { get; set; }
    }
}
