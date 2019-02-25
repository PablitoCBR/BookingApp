using BookingApp.Entities.Accounts;
using BookingApp.Dtos.Accounts;
using System.Collections.Generic;

namespace BookingApp.Interfaces.Services.Accounts
{
    public interface IBusinessService
    {
        Business Authenticate(string email, string password);
        BusinessDto Get(int id);
        void Create(Business business, string password);
        void Update(Business businessm, string password = null);
        void Delete(int id);
    }
}
