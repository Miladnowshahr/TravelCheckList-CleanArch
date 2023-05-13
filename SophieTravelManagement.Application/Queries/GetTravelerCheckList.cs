using SophieTravelManagement.Application.DTO;
using SophieTravelManagement.Shared.Abstraction.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Application.Queries
{
    public class GetTravelerCheckList:IQuery<TravelerCheckListDto>
    {
        public Guid Id { get; set; }
    }
}
