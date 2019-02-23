using BookingApp.Entities.Accounts;

namespace BookingApp.Interfaces.Repositories
{
    public interface IRepository<T> where T : Account
    {
        void Add (T data);
        void Remove (T data);
        void Update (T data);
        T Get (int id);
        T Get (string email);
    }
}
