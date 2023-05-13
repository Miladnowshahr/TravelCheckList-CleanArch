using SophieTravelManagement.Shared.Abstraction.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Application.Commands
{
    public record RemoveTravelerItem(Guid TravelerCheckListId,string Name):ICommand;
 }
