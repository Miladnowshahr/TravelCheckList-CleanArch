using SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.Policies
{
    internal interface ITravelerItemPolicy
    {
        bool IsApplicable(PolicyData data);

        IEnumerable<TravelerItem> GenerateItems(PolicyData data);
    }
}
