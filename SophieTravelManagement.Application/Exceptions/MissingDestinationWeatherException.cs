using SophieTravelManagement.Domain.ValueObjects;
using SophieTravelManagement.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Application.Exceptions
{
    public class MissingDestinationWeatherException : TravelerCheckListException
    {
        public Destination Destination { get; }
        public MissingDestinationWeatherException(Destination destination) :
            base($"Couldn't fetch weather data for destination '{destination.Country}/{destination.City}") 
        =>Destination = destination;
    }
}
