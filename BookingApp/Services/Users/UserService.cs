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
        private readonly UserContext _userContext;
        private readonly ErrorLogContext _errorLogContext;
        private readonly IPasswordHandler _passwordHandler;
        private readonly IUserDataValidator _userDataValidator;

        public UserService(UserContext context, ErrorLogContext errorLogContext, IPasswordHandler passwordHandler, IUserDataValidator userDataValidator)
        {
            _userContext = context;
            _errorLogContext = errorLogContext;
            _passwordHandler = passwordHandler;
            _userDataValidator = userDataValidator;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _userContext.Users.SingleOrDefault(x => x.Username == username);
 
            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            try
            {
                if (!_passwordHandler.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    return null;
            }
            catch (ArgumentException ex)
            { 
                return null;
            }
            catch (PasswordHandlerException ex)
            {
                var passwordExceptionLog = new PasswordExceptionLog()
                {
                    UserId = user.Id,
                    Time = ex.Time,
                    Message = ex.Message,
                    ParamName = ex.ParamName
                };
                _errorLogContext.PasswordExceptionLogs.Add(passwordExceptionLog);
                _errorLogContext.SaveChanges();
                return null;
            }
            user.Address = _userContext.Addresses.SingleOrDefault(x => x.Id == user.AddressId);

            // authentication successful
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.Users.Include(x => x.Address);
        }

        public User GetById(int id)
        {
            var user = _userContext.Users.Find(id);
            user.Address = _userContext.Addresses.Find(user.AddressId);
            return user;
        }

        public User Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_userContext.Users.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            if (!_userDataValidator.ValidateUser(user))
                throw new AppException("Invalid data!");

            byte[] passwordHash, passwordSalt;
            try
            {
                _passwordHandler.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            }
            catch (ArgumentException e)
            {
                throw new AppException(e.Message);
            }
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _userContext.Users.Add(user);
            _userContext.SaveChanges();

            return user;
        }

        public void Update(User userParam, string password = null)
        {
            //TO DO: Modify updateing with CurrentValues and SetValues
            var user = _userContext.Users.Find(userParam.Id);
           // var user = _userContext.Users.Include(u => u.Address).FirstOrDefault(u => u.Id == userParam.Id);
            if (user == null)
                throw new AppException("User not found");

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (_userContext.Users.Any(x => x.Username == userParam.Username))
                    throw new AppException("Username " + userParam.Username + " is already taken");
            }
            var address = _userContext.Addresses.Find(user.AddressId);
            //_userContext.Update(userParam.Address);
            // update user properties
            _userContext.Addresses.Remove(address);
            user.Address = userParam.Address;
            user.BusinessName = userParam.BusinessName;
            user.Username = userParam.Username;
            if (!_userDataValidator.ValidateUser(user))
                throw new AppException("Invalid data!");

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                try
                {
                    _passwordHandler.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                }
                catch (ArgumentException e)
                {
                    throw new AppException(e.Message);
                }
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _userContext.Users.Update(user);
            _userContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _userContext.Users.Find(id);

            if (user != null)
            {
                var address = _userContext.Addresses.Find(user.AddressId);
                _userContext.Users.Remove(user);
                _userContext.Addresses.Remove(address);

                _userContext.SaveChanges();
            }
            else throw new AppException("User not found!");
        }
    }
}
