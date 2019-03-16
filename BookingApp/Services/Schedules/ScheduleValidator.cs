using BookingApp.Dtos.Schedules;
using BookingApp.Entities.Schedules;

namespace BookingApp.Services.Schedules
{
    public class ScheduleValidator
    {
        public bool VerifySchedule(ScheduleDto scheduleDto)
        {
            if (!VerifyWorkingHours(scheduleDto.Monday))
                return false;
            if (!VerifyWorkingHours(scheduleDto.Thursday))
                return false;
            if (!VerifyWorkingHours(scheduleDto.Wednesday))
                return false;
            if (!VerifyWorkingHours(scheduleDto.Tuesday))
                return false;
            if (!VerifyWorkingHours(scheduleDto.Friday))
                return false;
            if (!VerifyWorkingHours(scheduleDto.Saturday))
                return false;
            if (!VerifyWorkingHours(scheduleDto.Sunday))
                return false;
            return true;
        }

        private bool VerifyWorkingHours(WorkingHours workingHours)
        {
            if (workingHours == null)
                return false;
            if (CheckTime(workingHours.Opening) && CheckTime(workingHours.Closeing))
                return true;
            return false;
        }

        private bool CheckTime(Time time)
        {
            if (time == null)
                return false;
            if (time.Minutes == null || time.Hours == null)
                return true;
            if (time.Hours >= 0 && time.Hours < 24 && time.Minutes >= 0 && time.Minutes < 60)
                return true;
            else return false;
        }
    }
}
