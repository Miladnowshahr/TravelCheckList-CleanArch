using SophieTravelManagement.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.Exceptions
{
    internal class InvalidTravelDaysException : TravelerCheckListException
    {
        public ushort Days { get; }
        public InvalidTravelDaysException(ushort days) : base($"Travel days '{days}' is invalid exception")
            => Days= days;
    }
}
