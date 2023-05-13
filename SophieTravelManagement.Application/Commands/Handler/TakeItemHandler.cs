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
    internal sealed class TakeItemHandler:ICommandHandler<TakeItem>
    {
        private readonly ITravelerCheckListRepository _repository;

        public TakeItemHandler(ITravelerCheckListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(TakeItem command)
        {
            var travelerCheckList = await _repository.GetAsync(command.TravelerCheckListId);
            if (travelerCheckList == null)
                throw new TravelerCheckListNotFound(command.TravelerCheckListId);

            travelerCheckList.TakeItem(command.Name);
            await _repository.UpdateAsync(travelerCheckList);
        }
    }
}
