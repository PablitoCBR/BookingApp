using BookingApp.Dtos.Schedules;

namespace BookingApp.Interfaces.Services
{
    public interface IScheduleService
    {
        void Create(int id, ScheduleDto scheduleDto);
        ScheduleDto Get(int id);
        void Update(int id, ScheduleDto scheduleDto);
        void Remove(int id);
    }
}
