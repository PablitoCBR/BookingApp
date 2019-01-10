using AutoMapper;
using BookingApp.Dtos.Users;
using BookingApp.Entities.Users;
using BookingApp.Entities.Schedules;
using BookingApp.Dtos.Schedules;

namespace BookingApp.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();

            CreateMap<Schedule, ScheduleDto>();
            CreateMap<ScheduleDto, Schedule>();

            CreateMap<Reservation, ReservationDto>();
            CreateMap<ReservationDto, Reservation>();
        }
    }
}
