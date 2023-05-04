using SophieTravelManagement.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.Exceptions
{
    internal class InvalidTemperatureException : TravelerCheckListException
    {
        public double Value { get; }
        public InvalidTemperatureException(double value) : base($"Value '{value}' is invalid temperature.")
        => Value = value;

    }
}
