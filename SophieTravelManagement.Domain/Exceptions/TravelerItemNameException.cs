using SophieTravelManagement.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.Exceptions
{
    internal class TravelerItemNameException : TravelerCheckListException
    {
        public TravelerItemNameException() : base("Traveler item name cannot be empty.")
        {
        }
    }
}
