using BookingApp.Entities.Accounts;

namespace BookingApp.Interfaces.Repositories
{
    public interface IAccountRepository<T> : IRepository<T> where T : Account
    {
        T Get(string email);
    }
}
