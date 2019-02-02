using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingApp.Interfaces.Services.Users;
using BookingApp.Entities.Users;
using BookingApp.Contextes.Users;
using BookingApp.Helpers;
using Microsoft.EntityFrameworkCore;
using BookingApp.Interfaces.Repositories;

namespace BookingApp.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ErrorLogContext _errorLogContext;
        private readonly IPasswordHandler _passwordHandler;
        private readonly IUserDataValidator _userDataValidator;

        public UserService(IUserRepository repository, ErrorLogContext errorLogContext, IPasswordHandler passwordHandler, IUserDataValidator userDataValidator)
        {
            _userRepository = repository;
            _errorLogContext = errorLogContext;
            _passwordHandler = passwordHandler;
            _userDataValidator = userDataValidator;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;
          
            try
            {
                User user = _userRepository.GetByUsername(username);
                if (!_passwordHandler.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    return null;
                return user;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            catch (ArgumentException)
            { 
                return null;
            }
            catch (PasswordHandlerException ex)
            {
                var passwordExceptionLog = new PasswordExceptionLog()
                {
                    Username = username,
                    Time = ex.Time,
                    Message = ex.Message,
                    ParamName = ex.ParamName
                };
                Task.Run(() => {
                    _errorLogContext.PasswordExceptionLogs.AddAsync(passwordExceptionLog);
                    _errorLogContext.SaveChangesAsync();
                });
                return null;
            }         
        }

        public User GetById(int id)
        {
            try
            {
                return _userRepository.GetById(id);
            }
            catch(NullReferenceException)
            {
                return null;
            }
        }

        public User Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_userRepository.CheckIfExistByUsername(user.Username))
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

            _userRepository.Add(user);

            return user;
        }

        public void Update(User userParam, string password = null)
        {
            User user;
            try
            {
                user = _userRepository.GetById(userParam.Id);
            }
            catch (NullReferenceException)
            {
                throw new AppException("User not found");
            }
                

            // Check if provided data is valid
            if (!_userDataValidator.ValidateUser(userParam))
                throw new AppException("Invalid data!");

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (_userRepository.CheckIfExistByUsername(userParam.Username))
                    throw new AppException("Username " + userParam.Username + " is already taken");
            }

            // Remove old address from DB
            _userRepository.RemoveAddress(user.Address);

            user.Address = userParam.Address;
            user.BusinessName = userParam.BusinessName;
            user.Username = userParam.Username;


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

            _userRepository.Update(user);
        }

        public void Delete(int id)
        {
            try
            {
                _userRepository.Remove(_userRepository.GetById(id));
            }
            catch(NullReferenceException)
            {
                throw new AppException("User not found!");
            }
        }
    }
}
