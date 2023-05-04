using SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.Policies.Gender
{
    internal sealed class MaleGenderPolicy : ITravelerItemPolicy
    {
        public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
        => new List<TravelerItem>()
        {
            new("Laptop",1),
            new("Drink",1),
            new("Book",(uint)Math.Ceiling(data.Days/7m))
        };

        public bool IsApplicable(PolicyData data)
           => data.Gender is Const.Gender.Male;
    }
}
