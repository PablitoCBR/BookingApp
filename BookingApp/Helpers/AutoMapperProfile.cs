using AutoMapper;
using BookingApp.Dtos.User;
using BookingApp.Entities.User;

namespace BookingApp.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
