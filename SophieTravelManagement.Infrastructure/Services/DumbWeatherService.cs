using SophieTravelManagement.Application.DTO.External;
using SophieTravelManagement.Application.Services;
using SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Infrastructure.Services
{
    internal sealed class DumbWeatherService : IWeatherService
    {
        public Task<WeatherDto> GetWeatherAsync(Destination localization)
            => Task.FromResult(new WeatherDto(new Random().Next(5, 30)));
    }
}
