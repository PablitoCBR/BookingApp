using System.Collections.Generic;

namespace BookingApp.Interfaces.Repositories
{
    public interface ISearchRepository<T>
    {
        ICollection<T> GetAll(string pattern);
    }
}
