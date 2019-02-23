using BookingApp.Entities.Accounts;
using BookingApp.Interfaces.Repositories;

namespace BookingApp.Interfaces.Security
{
    public interface IAccountManager<T> where T : Account
    {
        void CreateUser(T user, string password, IRepository<T> repository);
        T Authenticate(string email, string password, IRepository<T> repository);
        void Update(T user, IRepository<T> repository, string password = null);
    }
}
