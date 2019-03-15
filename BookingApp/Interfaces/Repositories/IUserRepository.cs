using BookingApp.Entities.Accounts;

namespace BookingApp.Interfaces.Repositories
{
    public interface IUserRepository : IAccountRepository<User>
    {
        bool CheckIfExist(string email);
    }
}
