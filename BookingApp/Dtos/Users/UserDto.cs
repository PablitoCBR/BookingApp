using BookingApp.Dtos.Schedules;

namespace BookingApp.Dtos.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public AddressDto Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
