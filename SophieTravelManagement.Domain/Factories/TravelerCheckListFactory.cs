using SophieTravelManagement.Domain.Const;
using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.Policies;
using SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.Factories
{
    internal class TravelerCheckListFactory : ITravelerCheckListFactory
    {
        private readonly IEnumerable<ITravelerItemPolicy> _policies;

        public TravelerCheckListFactory(IEnumerable<ITravelerItemPolicy> policies)
        {
            _policies = policies;
        }

        public TravelerCheckList Create(TravelerCheckListId id, TravelerCheckListName name, Destination destination)
        => new(id, name, destination);

        public TravelerCheckList CreateWithDefaultItems(TravelerCheckListId id, TravelerCheckListName name, TravelDays days, Gender gender, Temperature temperature, Destination destination)
        {
            var data = new PolicyData(days,gender,temperature,destination);

            var applicablePolicies = _policies.Where(p => p.IsApplicable(data));

            var items = applicablePolicies.SelectMany(p => p.GenerateItems(data));
            var travelerCheckingList = Create(id, name, destination);
            travelerCheckingList.AddItems(items);
            return travelerCheckingList;

        }
    }
}
