using BookingApp.Entities.Accounts;

namespace BookingApp.Interfaces.Repositories
{
    public interface IBusinessRepository : IAccountRepository<Business>, ISearchRepository<Business>
    {
        bool CheckIfExist(string email = null, string companyName = null);
    }
}
