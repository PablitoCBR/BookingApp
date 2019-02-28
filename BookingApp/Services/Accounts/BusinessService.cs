using BookingApp.Dtos.Accounts;
using BookingApp.Entities.Accounts;
using BookingApp.Interfaces.Services.Accounts;
using BookingApp.Interfaces.Repositories;
using BookingApp.Interfaces.Security;
using System;
using BookingApp.Exceptions;
using AutoMapper;


namespace BookingApp.Services.Accounts
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _repository;
        private readonly IAccountManager<Business> _accountManager;
        private readonly AddressValidator _addressValidator;
        private readonly IMapper _mapper;

        public BusinessService(IBusinessRepository repository, IMapper mapper,
            IAccountManager<Business> accountManager, AddressValidator addressValidator)
        {
            _repository = repository;
            _accountManager = accountManager;
            _addressValidator = addressValidator;
            _mapper = mapper;
        }

        public Business Authenticate(string email, string password)
        {
            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
                return null;

            return _accountManager.Authenticate(email, password, _repository);
        }

        public void Create(Business business, string password)
        {
            if (String.IsNullOrEmpty(password))
                throw new ValidationException("Password is rquired");
            if (_repository.CheckIfExist(business.Email, business.CompanyName))
                throw new ValidationException("Email or company name already in use");

            if (!_addressValidator.Validate(business.Address).Result)
                throw new ValidationException("Address is bad formated or missing data", business.Address);

            if (business.PhoneNumber.Length != 9)
                throw new ValidationException("Phone number is not valid", business.PhoneNumber);

            try
            {
                _accountManager.CreateUser(business, password, _repository);
            }
            catch(ValidationException ex)
            {
                throw new ValidationException(ex.Message, ex.Arguments);
            }
        }

        public void Delete(int id)
        {
            Business business = _repository.Get(id);
            if (business == null)
                throw new ValidationException("User not foud", id);
            _repository.Remove(business); 
        }

        public BusinessDto Get(int id)
        {
            Business business = _repository.Get(id);
            if (business == null)
                throw new ValidationException("User not found", id);

            return _mapper.Map<BusinessDto>(business);              
        }

        public void Update(Business businessParam, string password = null)
        {
            Business business = _repository.Get(businessParam.Id);
            if (business == null)
                throw new ValidationException("User not found", businessParam.Id);

            if (business.PhoneNumber.Length != 9)
                throw new ValidationException("Phone number is not valid", business.PhoneNumber);

            if (!_addressValidator.Validate(businessParam.Address).Result)
                throw new ValidationException("Address is bad formated or missing data", businessParam.Address);

            if (businessParam.Email != business.Email)
                if (_repository.CheckIfExist(businessParam.Email))
                    throw new ValidationException("Email already in use", businessParam.Email);
                else business.Email = businessParam.Email;
            if (businessParam.CompanyName != business.CompanyName)
                if (_repository.CheckIfExist(companyName: businessParam.CompanyName))
                    throw new ValidationException("Company name already in use", businessParam.CompanyName);
                else business.CompanyName = businessParam.CompanyName;

            business.Address = businessParam.Address;
            business.PhoneNumber = businessParam.PhoneNumber;

            _accountManager.Update(business, _repository, password);
        }
    }
}
