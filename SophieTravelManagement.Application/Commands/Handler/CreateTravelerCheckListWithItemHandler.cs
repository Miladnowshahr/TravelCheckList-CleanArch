using SophieTravelManagement.Application.Exceptions;
using SophieTravelManagement.Application.Services;
using SophieTravelManagement.Domain.Factories;
using SophieTravelManagement.Domain.Repositories;
using SophieTravelManagement.Domain.ValueObjects;
using SophieTravelManagement.Shared.Abstraction.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Application.Commands.Handler
{
    internal sealed class CreateTravelerCheckListWithItemHandler : ICommandHandler<CreateTravelerCheckListWithItem>
    {
        private readonly ITravelerCheckListRepository _repository;
        private readonly IWeatherService _weatherService;
        private readonly ITravelerCheckListFactory _factory;
        private readonly ITravelerCheckListReadService _readService;
        public CreateTravelerCheckListWithItemHandler(ITravelerCheckListRepository repository, IWeatherService weatherService, ITravelerCheckListFactory factory, ITravelerCheckListReadService readService)
        {
            _repository = repository;
            _weatherService = weatherService;
            _factory = factory;
            _readService = readService;
        }

        public async Task HandleAsync(CreateTravelerCheckListWithItem command)
        {
            var (id, name, days, gender, destinationWriteModel) = command;

            if (await _readService.ExistsByNameAsync(name))
                throw new TravelerCheckListAlreadyExistsException(name);

            var destination = new Destination(destinationWriteModel.City, destinationWriteModel.Country);
            var weather = await _weatherService.GetWeatherAsync(destination);

            if (weather is null)
                throw new MissingDestinationWeatherException(destination);

            var travelerCheckList = _factory.CreateWithDefaultItems(id, name, days, gender, weather.Temperature, destination);

            await _repository.AddAsync(travelerCheckList);
        }
    }
}
