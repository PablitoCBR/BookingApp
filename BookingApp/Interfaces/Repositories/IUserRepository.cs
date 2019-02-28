using BookingApp.Entities.Accounts;

namespace BookingApp.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        bool CheckIfExist(string email);
    }
}
