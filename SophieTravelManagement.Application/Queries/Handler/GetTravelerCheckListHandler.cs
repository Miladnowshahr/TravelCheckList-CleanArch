using SophieTravelManagement.Application.DTO;
using SophieTravelManagement.Domain.Repositories;
using SophieTravelManagement.Shared.Abstraction.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Application.Queries.Handler
{
    public class GetTravelerCheckListHandler : IQueryHandler<GetTravelerCheckList, TravelerCheckListDto>
    {
        private readonly ITravelerCheckListRepository? _repository;

        public GetTravelerCheckListHandler(ITravelerCheckListRepository? repository)
        {
            _repository = repository;
        }

        public async Task<TravelerCheckListDto> HandleAsync(GetTravelerCheckList query)
        {
            var travelerCheckList = await _repository.GetAsync(query.Id);

            return null;

        }
    }
}
