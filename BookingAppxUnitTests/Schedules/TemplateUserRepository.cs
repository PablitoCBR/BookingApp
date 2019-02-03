using BookingApp.Entities.Users;
using BookingApp.Interfaces.Repositories;

namespace BookingAppxUnitTests.Schedules
{
    class TemplateUserRepository : IUserRepository
    {
        public void Add(User user)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckIfExistById(int id)
        {
            return true;
        }

        public bool CheckIfExistByUsername(string username)
        {
            return true;
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(User user)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAddress(Address address)
        {
            throw new System.NotImplementedException();
        }

        public void Update(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
