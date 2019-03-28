using BookingApp.Entities.Accounts;
using BookingApp.Dtos.Accounts;

namespace BookingApp.Interfaces.Services
{
    public interface IBusinessService
    {
        Business Authenticate(string email, string password);
        BusinessDto Get(int id);
        void Create(Business business, string password);
        void Update(Business businessParam, string password = null);
        void Delete(int id);
    }
}
