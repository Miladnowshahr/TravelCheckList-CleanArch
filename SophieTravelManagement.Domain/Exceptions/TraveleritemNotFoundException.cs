using SophieTravelManagement.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.Exceptions
{
    public class TraveleritemNotFoundException : TravelerCheckListException
    {
        public string ItemName { get; }
        public TraveleritemNotFoundException(string itemName) : base($"Traveler item '{itemName} cannot be found.'") => ItemName = itemName;
        
    }
}
