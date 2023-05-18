using NSubstitute;
using Shouldly;
using SophieTravelManagement.Application.Commands;
using SophieTravelManagement.Application.Commands.Handler;
using SophieTravelManagement.Application.DTO.External;
using SophieTravelManagement.Application.Exceptions;
using SophieTravelManagement.Application.Services;
using SophieTravelManagement.Domain.Const;
using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.Factories;
using SophieTravelManagement.Domain.Repositories;
using SophieTravelManagement.Domain.ValueObjects;
using SophieTravelManagement.Shared.Abstraction.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.UnitTests.Application
{
    public class CreateTravelerCheckListWithItemsHandlerTests
    {
        Task Act(CreateTravelerCheckListWithItem command) => _commandHandler.HandleAsync(command);



        [Fact]
        public async Task Handle_Async_Throws_TravelerCheckListAlreadyExistsException_When_List_With_Sam_Name_Already_Exists()
        {
            var command = new CreateTravelerCheckListWithItem(Guid.NewGuid(), "MyList", 10,Gender.Female, default);
            _readService.ExistsByNameAsync(command.Name).Returns(true);
            
            var exception = await Record.ExceptionAsync(()=>Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<TravelerCheckListAlreadyExistsException>();

        }

        [Fact]
        public async Task HandleAsync_Throws_MissingDestinationWeatherException_When_Weather_Is_Not_Returned_From_Service()
        {
            var command = new CreateTravelerCheckListWithItem(Guid.NewGuid(), "MyList", 10, Gender.Female, new DestinationWriteModel("Teh", "Iran"));

            _readService.ExistsByNameAsync(command.Name).Returns(false);
            _weatherService.GetWeatherAsync(Arg.Any<Destination>()).Returns(default(WeatherDto));

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingDestinationWeatherException>();
        }

        [Fact]
        public async Task HandleAsync_Calls_Repository_On_Success()
        {
            var command = new CreateTravelerCheckListWithItem(Guid.NewGuid(), "MyList", 10, Gender.Female,
                new DestinationWriteModel("ESF", "Iran"));

            _readService.ExistsByNameAsync(command.Name).Returns(false);
            _weatherService.GetWeatherAsync(Arg.Any<Destination>()).Returns(new WeatherDto(12));
            _factory.CreateWithDefaultItems(command.Id, command.Name, command.Days, command.Gender,
                Arg.Any<Temperature>(), Arg.Any<Destination>()).Returns(default(TravelerCheckList));

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldBeNull();
            await _repository.Received(1).AddAsync(Arg.Any<TravelerCheckList>());
        }



        #region ARRANGE
        private readonly ICommandHandler<CreateTravelerCheckListWithItem> _commandHandler;
        private readonly ITravelerCheckListRepository _repository;
        private readonly IWeatherService _weatherService;
        private readonly ITravelerCheckListReadService _readService;
        private readonly ITravelerCheckListFactory _factory;

        public CreateTravelerCheckListWithItemsHandlerTests()
        {
            _repository = Substitute.For<ITravelerCheckListRepository>();
            _weatherService = Substitute.For<IWeatherService>();
            _readService = Substitute.For<ITravelerCheckListReadService>();
            _factory = Substitute.For<ITravelerCheckListFactory>();
            _commandHandler = new CreateTravelerCheckListWithItemHandler(_repository,_weatherService,_factory,_readService);

        }

        #endregion
    }
}
