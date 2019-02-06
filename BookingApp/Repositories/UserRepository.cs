using BookingApp.Entities.Users;
using BookingApp.Interfaces.Repositories;
using BookingApp.Contextes;
using System.Linq;
using System;

namespace BookingApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;
        
        public UserRepository(UserContext context)
        {
            _userContext = context;
        }
        public void Add(User user)
        {
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
        }

        public bool CheckIfExistById(int id)
        {
            return _userContext.Users.Any(x => x.Id == id);
        }

        public bool CheckIfExistByUsername(string username)
        {
            return _userContext.Users.Any(x => x.Username == username);
        }

     
        public User GetById(int id)
        {
            User user = _userContext.Users.Find(id);
            if (user == null)
                throw new NullReferenceException();

            user.Address = GetAdrressById(user.AddressId);
            return user;
        }

        public User GetByUsername(string username)
        {
            User user = _userContext.Users.SingleOrDefault(x => x.Username == username);
            if (user == null)
                throw new NullReferenceException();

            user.Address = GetAdrressById(user.AddressId);
            return user;
        }

        public void Remove(User user)
        {
            _userContext.Addresses.Remove(user.Address);
            _userContext.Users.Remove(user);
            _userContext.SaveChanges();
        }

        public void Update(User user)
        {
            _userContext.Users.Update(user);
            _userContext.SaveChanges();
        }
        public void RemoveAddress(Address address)
        {
            _userContext.Addresses.Remove(address);
        }

        private Address GetAdrressById(int id)
        {
            return _userContext.Addresses.SingleOrDefault(x => x.Id == id);
        }
    }
}
