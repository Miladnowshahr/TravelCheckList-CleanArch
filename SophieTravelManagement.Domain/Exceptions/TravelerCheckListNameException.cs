using SophieTravelManagement.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.Exceptions
{
    internal class TravelerCheckListNameException : TravelerCheckListException
    {
        public TravelerCheckListNameException() : base("Traveler check list name cannot be empty.")
        {
        }
    }
}
