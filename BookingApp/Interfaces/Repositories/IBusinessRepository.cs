using BookingApp.Entities.Accounts;

namespace BookingApp.Interfaces.Repositories
{
    public interface IBusinessRepository : IRepository<Business>
    {
        bool CheckIfExist(string email = null, string companyName = null);
    }
}
