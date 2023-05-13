using SophieTravelManagement.Domain.Const;
using SophieTravelManagement.Domain.ValueObjects;
using SophieTravelManagement.Shared.Abstraction.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Application.Commands
{
    public record CreateTravelerCheckListWithItem(Guid Id,string Name,ushort Days, Gender Gender,DestinationWriteModel Destination):ICommand;

    public record DestinationWriteModel(string City,string Country);
}
