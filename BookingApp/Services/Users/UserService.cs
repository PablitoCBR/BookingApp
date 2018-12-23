using System;
using System.Collections.Generic;
using System.Linq;
using BookingApp.Interfaces.Users;
using BookingApp.Entities.Users;
using BookingApp.Contextes.Users;
using BookingApp.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserContext _context;
        private readonly IPasswordHandler _passwordHandler;

        public UserService(UserContext context, IPasswordHandler passwordHandler)
        {
            _context = context;
            _passwordHandler = passwordHandler;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Username == username);
 
            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            try
            {
                if (!_passwordHandler.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    return null;
            }
            catch (Exception e)
            {
                // Implement loggic for recording exceptions in app
                return null;
            }
            user.Address = _context.Addresses.SingleOrDefault(x => x.Id == user.AddressId);

            // authentication successful
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public User Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Users.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");
            if (user.Address == null)
                throw new AppException("Address is required!");

            byte[] passwordHash, passwordSalt;
            try
            {
                _passwordHandler.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            }
            catch (Exception e)
            {
                //Implement logic for logging exceptions
                throw new AppException(e.Message);
            }
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Update(User userParam, string password = null)
        {
            var user = _context.Users.Find(userParam.Id);

            if (user == null)
                throw new AppException("User not found");

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (_context.Users.Any(x => x.Username == userParam.Username))
                    throw new AppException("Username " + userParam.Username + " is already taken");
            }

            //var address = _context.Addresses.Find(user.AddressId);
            // update user properties
            user.BusinessName = userParam.BusinessName;
            user.Address = userParam.Address;
            user.Username = userParam.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                try
                {
                    _passwordHandler.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                }
                catch (Exception e)
                {
                    throw new AppException(e.Message);
                }
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            
            if (user != null)
            {
                var address = _context.Addresses.Find(user.AddressId);
                _context.Users.Remove(user);
                //_context.Addresses.Remove(address);
                
                _context.SaveChanges();
            }
        }
    }
}
