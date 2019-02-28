using BookingApp.Interfaces.Repositories;
using BookingApp.Contextes;
using BookingApp.Entities.Accounts;
using System.Linq;

namespace BookingApp.Repositories
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly AccountsContext _context;
        public BusinessRepository(AccountsContext context)
        {
            _context = context;
        }

        public void Add(Business data)
        {
            _context.Businesses.Add(data);
            _context.SaveChanges();
        }

        public void Remove(Business data)
        {
            _context.Addresses.Remove(data.Address);
            _context.Businesses.Remove(data);
            _context.SaveChanges();
        }

        public void Update(Business data)
        {
            _context.Businesses.Update(data);
            _context.SaveChanges();
        }

        public bool CheckIfExist(string email = null, string companyName = null) 
            => _context.Businesses.Any(x => x.Email == email || x.CompanyName == companyName);


        public Business Get(int id)
        {
            Business business = _context.Businesses.SingleOrDefault(x => x.Id == id);
            _context.Entry(business).Reference(b => b.Address).Load();
            return business;
        }

        public Business Get(string email) => _context.Businesses.SingleOrDefault(x => x.Email == email);
    }
}
