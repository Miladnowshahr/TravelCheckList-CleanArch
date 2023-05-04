using SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.Policies.Temperature
{
    internal sealed class LowTemperaturePolicy : ITravelerItemPolicy
    {
        public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
            => new List<TravelerItem>()
            {
                new("Winter hat",1),
                new("Scarf",1),
                new("Gloves",1),
                new("Hoodie",1),
                new("Warm jacket",1)
            };
        public bool IsApplicable(PolicyData data)
        => data.Temperature < 10D;
    }
}
