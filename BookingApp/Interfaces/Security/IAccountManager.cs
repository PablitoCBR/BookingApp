using BookingApp.Entities.Accounts;
using BookingApp.Interfaces.Repositories;

namespace BookingApp.Interfaces.Security
{
    public interface IAccountManager<T> where T : Account
    {       
        void CreateUser(T user, string password, IAccountRepository<T> repository);
        T Authenticate(string email, string password, IAccountRepository<T> repository);
        void Update(T user, IAccountRepository<T> repository,string password = null);
    }
}
