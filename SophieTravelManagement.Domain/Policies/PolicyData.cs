using SophieTravelManagement.Domain.Const;
using SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.Policies
{
    public record PolicyData(TravelDays Days,SophieTravelManagement.Domain.Const.Gender Gender, SophieTravelManagement.Domain.ValueObjects.Temperature Temperature, Destination Destination);
}
