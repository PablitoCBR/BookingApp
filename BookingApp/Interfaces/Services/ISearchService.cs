using BookingApp.Dtos.Accounts;
using System.Collections.Generic;

namespace BookingApp.Interfaces.Services
{
    public interface ISearchService
    {
        ICollection<BusinessSearchResultsDto> SearchByCompanyName(string comapnyName);
    }
}
