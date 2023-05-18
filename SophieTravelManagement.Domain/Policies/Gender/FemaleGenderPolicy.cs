using SophieTravelManagement.Domain.Const;
using SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.Policies.Gender
{
    internal class FemaleGenderPolicy : ITravelerItemsPolicy
    {
        public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
        => new List<TravelerItem>
        {
            new("Powder",1),
            new("Lipstick",1),
            new("Eyeliner",1)
        };

        //09907269740

        public bool IsApplicable(PolicyData data)
        => data.Gender is Const.Gender.Female;

    }
}
