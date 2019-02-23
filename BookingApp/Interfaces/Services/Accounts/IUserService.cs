using BookingApp.Entities.Accounts;
using BookingApp.Dtos.Accounts;


namespace BookingApp.Interfaces.Services.Accounts
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        UserDto GetById(int id);
        void Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
