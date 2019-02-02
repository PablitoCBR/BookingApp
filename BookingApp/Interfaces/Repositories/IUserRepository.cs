using BookingApp.Entities.Users;

namespace BookingApp.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
        User GetById(int id);
        bool CheckIfExistByUsername(string username);
        bool CheckIfExistById(int id);
        void Add(User user);
        void Update(User user);
        void Remove(User user);
        void RemoveAddress(Address address);
    }
}
