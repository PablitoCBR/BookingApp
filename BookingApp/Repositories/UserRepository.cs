using BookingApp.Interfaces.Repositories;
using BookingApp.Entities.Accounts;
using BookingApp.Contextes;
using System.Linq;

namespace BookingApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookingAppContext _context;

        public UserRepository(BookingAppContext context)
        {
            _context = context;
        }

        public void Add(User data)
        {
            _context.Users.Add(data);
            _context.SaveChanges();
        }

        public void Remove(User data)
        {
            _context.Users.Remove(data);
            _context.SaveChanges();
        }

        public void Update(User data)
        {
            _context.Users.Update(data);
            _context.SaveChanges();
        }

        public User Get(int id) => _context.Users.SingleOrDefault(x => x.Id == id);

        public User Get(string email) => _context.Users.SingleOrDefault(x => x.Email == email);

        public bool CheckIfExist(string email) => _context.Users.Any(x => x.Email == email);

    }
}
