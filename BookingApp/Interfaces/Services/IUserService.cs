using BookingApp.Entities.Accounts;
using BookingApp.Dtos.Accounts;

namespace BookingApp.Interfaces.Services
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        UserDto Get(int id);
        void Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
