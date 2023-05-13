using SophieTravelManagement.Application.DTO;
using SophieTravelManagement.Shared.Abstraction.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Application.Queries
{
    internal class SearchTravelerCheckList:IQuery<IEnumerable<TravelerCheckListDto>>
    {
        public string SearchPhrase { get; set; }
    }
}
