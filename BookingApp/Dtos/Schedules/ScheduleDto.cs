﻿using BookingApp.Entities.Schedules;

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
}
