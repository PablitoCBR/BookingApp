using AutoMapper;
using BookingApp.Dtos.Accounts;
using BookingApp.Entities.Accounts;
using BookingApp.Entities.Schedules;
using BookingApp.Dtos.Schedules;
using System;
using BookingApp.Dtos.Reservations;
using BookingApp.Entities.Reservations;

namespace BookingApp.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Business, BusinessDto>();
            CreateMap<BusinessDto, Business>();

            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();

            CreateMap<Schedule, ScheduleDto>();
            CreateMap<ScheduleDto, Schedule>();

            CreateMap<ReservationDto, Reservation>();
            CreateMap<Reservation, ReservationDto>();

            CreateMap<WorkingHoursDto, WorkingHours>()
                .ForMember(dest => dest.Opening, opts => opts.MapFrom(
                    src => new Time()
                    {
                        Hours = src.Opening != null
                            ? System.Convert.ToInt32(src.Opening.Substring(0, src.Opening.IndexOf(":")))
                            : new int?(),
                        Minutes = src.Opening != null
                            ? System.Convert.ToInt32(src.Opening.Substring(src.Opening.IndexOf(":") + 1))
                            : new int?()
                    }
                ))
                .ForMember(dest => dest.Closing, opts => opts.MapFrom(
                    src => new Time()
                    {
                        Hours = src.Closing != null
                            ? System.Convert.ToInt32(src.Closing.Substring(0, src.Closing.IndexOf(":")))
                            : new int?(),
                        Minutes = src.Closing != null
                            ? System.Convert.ToInt32(src.Closing.Substring(src.Closing.IndexOf(":") + 1))
                            : new int?()
                    }
                ));
            CreateMap<WorkingHours, WorkingHoursDto>()
                .ForMember(dest => dest.Opening, opts => opts.MapFrom(
                    src => src.Opening.Hours != null ? src.Opening.ToString() : null
                ))
                .ForMember(dest => dest.Closing, opts => opts.MapFrom(
                    src => src.Closing.Hours != null ? src.Closing.ToString() : null
                ));
        }
    }
}