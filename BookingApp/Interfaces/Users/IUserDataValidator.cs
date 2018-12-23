using BookingApp.Entities.Users;

namespace BookingApp.Interfaces.Users
{
    public interface IUserDataValidator
    {
        bool ValidateUser(User user);
        bool ValidateAddress(Address address);
        bool ValidatePostalCode(string postalCode);
    }
}
