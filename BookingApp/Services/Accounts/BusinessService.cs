using BookingApp.Dtos.Accounts;
using BookingApp.Entities.Accounts;
using BookingApp.Interfaces.Services.Accounts;
using System.Collections.Generic;

namespace BookingApp.Services.Accounts
{
    public class BusinessService : IBusinessService
    {
        public Business Authenticate(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Business business, string password)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public BusinessDto Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Business businessm, string password = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
