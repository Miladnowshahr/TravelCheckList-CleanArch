using SophieTravelManagement.Application.Exceptions;
using SophieTravelManagement.Domain.Repositories;
using SophieTravelManagement.Shared.Abstraction.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Application.Commands.Handler
{
    internal sealed class RemoveTravelerCheckListHandler:ICommandHandler<RemoveTravelerCheckList>
    {
        private readonly ITravelerCheckListRepository _repository;

        public RemoveTravelerCheckListHandler(ITravelerCheckListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(RemoveTravelerCheckList command)
        {
            var travelerCheckList = await _repository.GetAsync(command.Id);

            if (travelerCheckList == null)
                throw new TravelerCheckListNotFound(command.Id);

            await _repository.DeleteAsync(travelerCheckList);
        }
    }
}
