using Microsoft.EntityFrameworkCore;
using SophieTravelManagement.Application.DTO;
using SophieTravelManagement.Application.Queries;
using SophieTravelManagement.Domain.Repositories;
using SophieTravelManagement.Infrastructure.EF.Context;
using SophieTravelManagement.Infrastructure.EF.Models;
using SophieTravelManagement.Shared.Abstraction.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Infrastructure.EF.Queries.Handlers
{
    internal class GetTravelerCheckListHandler:IQueryHandler<GetTravelerCheckList, TravelerCheckListDto>
    {
        private readonly DbSet<TravelerCheckListReadModel> _travelerCheckLists;

        public GetTravelerCheckListHandler(ReadDbContext context)
            => _travelerCheckLists = context.TravelerCheckList;

        public async Task<TravelerCheckListDto> HandleAsync(GetTravelerCheckList query)
            => await _travelerCheckLists
            .Include(i => i.Items)
            .Where(pl => pl.Id == query.Id)
            .Select(s=>s.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();                       
    }
}
