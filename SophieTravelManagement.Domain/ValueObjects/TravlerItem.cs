using SophieTravelManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.ValueObjects
{
    public record TravelerItem
    {
        public string Name { get; }
        public uint Qunatity { get; }
        public bool IsTaken { get; init; }
        public TravelerItem(string name,uint qunatity, bool isToken = false)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new TravelerItemNameException();
            Name = name;
            Qunatity= qunatity;
            IsToken= isToken;
        }
    }
}
