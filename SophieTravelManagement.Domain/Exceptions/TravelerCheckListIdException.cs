using SophieTravelManagement.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.Exceptions
{
    public class TravelerCheckListIdException : TravelerCheckListException
    {
        public TravelerCheckListIdException():base("Traveler Checklist Id cannot be empty.")
        {
        }
    }
}
