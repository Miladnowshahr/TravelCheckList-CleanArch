using Microsoft.EntityFrameworkCore;
using SophieTravelManagement.Application.Services;
using SophieTravelManagement.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Infrastructure.EF.Services
{
    internal sealed class TravelerCheckListReadService : ITravelerCheckListReadService
    {
        private readonly DbSet<TravelerCheckListReadModel> _travelerCheckList;

        public TravelerCheckListReadService(DbSet<TravelerCheckListReadModel> travelerCheckList)
        {
            _travelerCheckList = travelerCheckList;
        }

        public Task<bool> ExistsByNameAsync(string name)
            =>  _travelerCheckList.AnyAsync(pl=>pl.Name == name);
    }
}
