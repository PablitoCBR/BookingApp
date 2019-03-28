using BookingApp.Entities.Schedules;

namespace BookingApp.Dtos.Schedules
{
    public class ScheduleDto
    {
        public WorkingHoursDto Monday { get; set; }
        public WorkingHoursDto Tuesday { get; set; }
        public WorkingHoursDto Wednesday { get; set; }
        public WorkingHoursDto Thursday { get; set; }
        public WorkingHoursDto Friday { get; set; }
        public WorkingHoursDto Saturday { get; set; }
        public WorkingHoursDto Sunday { get; set; }
    }
}
