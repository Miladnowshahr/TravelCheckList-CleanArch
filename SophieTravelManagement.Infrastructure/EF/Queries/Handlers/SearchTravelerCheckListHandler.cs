﻿using Microsoft.EntityFrameworkCore;
using SophieTravelManagement.Application.DTO;
using SophieTravelManagement.Application.Queries;
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
    internal sealed class SearchTravelerCheckListHandler : IQueryHandler<SearchTravelerCheckList, IEnumerable<TravelerCheckListDto>>
    {
        private readonly DbSet<TravelerCheckListReadModel> _TravelerCheckLists;

        public SearchTravelerCheckListHandler(ReadDbContext context)
            => _TravelerCheckLists = context.TravelerCheckList;

        public async Task<IEnumerable<TravelerCheckListDto>> HandleAsync(SearchTravelerCheckList query)
        {
            var dbQuery = _TravelerCheckLists
                .Include(pl => pl.Items)
            .AsQueryable();

            if (query.SearchPhrase is not null)
            {
                dbQuery = dbQuery.Where(pl =>
                    Microsoft.EntityFrameworkCore.EF.Functions.Like(pl.Name, $"%{query.SearchPhrase}%"));
            }

            return await dbQuery
                .Select(pl => pl.AsDto())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
