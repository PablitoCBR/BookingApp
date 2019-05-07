using BookingApp.Entities.Schedules;

namespace BookingApp.Services.Schedules
{
    public class ScheduleValidator
    {
        public bool VerifySchedule(Schedule schedule)
        {
            if (!VerifyWorkingHours(schedule.Monday))
                return false;
            if (!VerifyWorkingHours(schedule.Thursday))
                return false;
            if (!VerifyWorkingHours(schedule.Wednesday))
                return false;
            if (!VerifyWorkingHours(schedule.Tuesday))
                return false;
            if (!VerifyWorkingHours(schedule.Friday))
                return false;
            if (!VerifyWorkingHours(schedule.Saturday))
                return false;
            if (!VerifyWorkingHours(schedule.Sunday))
                return false;
            return true;
        }

        private bool VerifyWorkingHours(WorkingHours workingHours)
        {
            if (workingHours == null)
                return false;
            if (CheckTime(workingHours.Opening) && CheckTime(workingHours.Closing))
                return true;
            else return false;
        }

        private bool CheckTime(Time time)
        {
            if (time.Hours == null || time.Minutes == null)
                return true;
            if (time.Hours >= 0 && time.Hours < 24 && time.Minutes >= 0 && time.Minutes < 60)
                return true;
            else return false;
        }
    }
}
