using Microsoft.AspNetCore.Mvc;
using SophieTravelManagement.Application.Commands;
using SophieTravelManagement.Application.DTO;
using SophieTravelManagement.Application.Queries;
using SophieTravelManagement.Shared.Abstraction.Command;
using SophieTravelManagement.Shared.Abstraction.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.API.Controllers
{
    public class TravelerCheckListController:BaseController
    {

        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public TravelerCheckListController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<ActionResult<TravelerCheckListDto>> Get([FromRoute] GetTravelerCheckList query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelerCheckListDto>>> Get([FromQuery] SearchTravelerCheckList query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);    
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTravelerCheckListWithItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        [HttpPut("{TravelerCheckListId}/items")]
        public async Task<IActionResult> Put([FromBody] AddTravelerItem command)
        { 
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpPut("{TravelerCheckListId:guid}/items/{name}/take")]
        public async Task<IActionResult> Put([FromBody] TakeItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromBody] RemoveTravelerCheckList command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpDelete("{travelerCheckListId:guid}/items/{name}")]
        public async Task<IActionResult> Delete([FromBody] RemoveTravelerItem command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }


    }
}
