using BookingApp.Interfaces.Repositories;
using BookingApp.Exceptions;
using BookingApp.Interfaces.Security;
using BookingApp.Entities.Accounts;
using System;
using Microsoft.Extensions.Logging;

namespace BookingApp.Security
{
    public class AccountManager<T> : IAccountManager<T> where T : Account
    {
        private readonly IPasswordHandler _passwordHandler;
        private readonly ILoggerFactory _loggerFactory;

        public AccountManager(IPasswordHandler passwordHandler, ILoggerFactory loggerFactory)
        {
            _passwordHandler = passwordHandler;
            _loggerFactory = loggerFactory;
        }

        public void CreateUser(T user, string password, IAccountRepository<T> repository)
        {
            byte[] passwordHash, passwordSalt;
            try
            {
                _passwordHandler.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            }
            catch(ArgumentException e)
            {
                throw new ValidationException(e.Message, e.ParamName);
            }
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            repository.Add(user);                
        }

        public T Authenticate(string email, string password, IAccountRepository<T> repository)
        {
            try
            {
                T user = repository.Get(email);
                if (!_passwordHandler.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    return null;
                return user;
            }
            catch(NullReferenceException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (PasswordHandlerException ex)
            {
                ILogger logger = _loggerFactory.CreateLogger("Password error logger");
                logger.LogCritical(ex, ex.Message, ex.ParamName, ex.Data);
                return null;
            }
        }

        public void Update(T user, IAccountRepository<T> repository,string password = null)
        {
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                try
                {
                    _passwordHandler.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                }
                catch (ArgumentException e)
                {
                    throw new ValidationException(e.Message);
                }
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            repository.Update(user);
        }
    }
}
