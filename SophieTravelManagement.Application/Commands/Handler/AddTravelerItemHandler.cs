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
    internal sealed class AddTravelerItemHandler:ICommandHandler<AddTravelerItem>
    {
        private readonly ITravelerCheckListRepository _repository;

        public AddTravelerItemHandler(ITravelerCheckListRepository repositoy)
        {
            _repository= repositoy;
        }

        public async Task HandleAsync(AddTravelerItem command)
        {
            var travelerCheckingList = await _repository.GetAsync(command.TravelerCheckListId);
            if (travelerCheckingList == null)
                throw new TravelerCheckListNotFound(command.TravelerCheckListId);

            var travelerItem = new TravelerItem(command.Name, command.Quantity);
            travelerCheckingList.AddItem(travelerItem);

            await _repository.UpdateAsync(travelerCheckingList);
        }
    }
}
