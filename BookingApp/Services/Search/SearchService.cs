using System.Collections.Generic;
using AutoMapper;
using BookingApp.Dtos.Accounts;
using BookingApp.Entities.Accounts;
using BookingApp.Interfaces.Repositories;
using BookingApp.Interfaces.Services;

namespace BookingApp.Services.Search
{
    public class SearchService : ISearchService
    {
        private readonly ISearchRepository<Business> _repository;
        private readonly IMapper _mapper;

        public SearchService(IBusinessRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public ICollection<BusinessSearchResultsDto> SearchByCompanyName(string comapnyName)
        {
            return _mapper.Map<IList<BusinessSearchResultsDto>>(_repository.GetAll(comapnyName));
        }
    }
}
