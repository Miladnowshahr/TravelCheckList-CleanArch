using SophieTravelManagement.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Application.Exceptions
{
    public class TravelerCheckListNotFound : TravelerCheckListException
    {
        public Guid Id { get; }
        public TravelerCheckListNotFound(Guid id) : base($"Traveler Checklist list with Id '{id}' not found.") => Id = id;
    }
}
