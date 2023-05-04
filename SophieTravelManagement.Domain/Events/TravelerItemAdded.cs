using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.ValueObjects;
using SophieTravelManagement.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.Events
{
    public record TravelerItemAdded(TravelerCheckList TravelerCheckList,TravelerItem TravelerItem):IDomainEvent;
    
}
