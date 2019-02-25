using AutoMapper;
using BookingApp.Dtos.Accounts;
using BookingApp.Entities.Accounts;


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
        }
    }
}
