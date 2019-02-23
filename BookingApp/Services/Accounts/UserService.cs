using System;
using BookingApp.Interfaces.Services.Accounts;
using BookingApp.Entities.Accounts;
using BookingApp.Exceptions;
using BookingApp.Interfaces.Repositories;
using BookingApp.Dtos.Accounts;
using AutoMapper;
using BookingApp.Interfaces.Security;


namespace BookingApp.Services.Accounts
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAccountManager<User> _accountManager;

        public UserService(IUserRepository repository, IMapper mapper, IAccountManager<User> accountManager)
        {
            _userRepository = repository;
            _mapper = mapper;
            _accountManager = accountManager;
        }

        public User Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            return _accountManager.Authenticate(email, password, _userRepository);     
        }

        public UserDto GetById(int id)
        {
            User user = _userRepository.Get(id);

            if (user == null)
                throw new ValidationException("User not found", id);
            
            return _mapper.Map<UserDto>(user);
        }

        public void Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ValidationException("Password is required");

            if (_userRepository.CheckIfExist(user.Email))
                throw new ValidationException("Email already exist", user.Email);

            try
            {
                _accountManager.CreateUser(user, password, _userRepository);
            }
            catch(ValidationException ex)
            {
                throw new ValidationException(ex.Message, ex.Arguments);
            }                
        }

        public void Update(User userParam, string password = null)
        {
            User user = _userRepository.Get(userParam.Id);

            if (user == null)
                throw new ValidationException("User not found", userParam.Id);

            if (userParam.Email != user.Email)
            {
                // email has changed so check if the new email is already taken
                if (_userRepository.CheckIfExist(userParam.Email))
                    throw new ValidationException("Email already exist", userParam.Email);
            }

            _accountManager.Update(userParam, _userRepository, password);
        }

        public void Delete(int id)
        {
            User user = _userRepository.Get(id);
            if (user == null)
                throw new ValidationException("User not found", id);
            _userRepository.Remove(user);
        }
    }
}
