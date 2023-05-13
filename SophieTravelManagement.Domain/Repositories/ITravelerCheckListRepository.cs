using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.Repositories
{
    public interface ITravelerCheckListRepository
    {
        Task<TravelerCheckList> GetAsync(TravelerCheckListId id);
        Task AddAsync(TravelerCheckList item);
        Task UpdateAsync(TravelerCheckList item);
        Task DeleteAsync(TravelerCheckList item);

    }
}
