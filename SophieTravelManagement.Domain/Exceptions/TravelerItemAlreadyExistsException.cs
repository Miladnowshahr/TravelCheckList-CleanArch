using SophieTravelManagement.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.Exceptions
{
    public class TravelerItemAlreadyExistsException : TravelerCheckListException
    {
        public string ListName { get; }
        public string ItemName { get; }


        public TravelerItemAlreadyExistsException(string listName, string itemName) : base($"Traveler Check List :'{listName}' already defined item '{itemName}")
        {
            ListName = listName;
            ItemName = itemName;
        }
    }
}
