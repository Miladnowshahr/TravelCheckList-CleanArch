﻿using Microsoft.Extensions.Logging;
using SophieTravelManagement.Shared.Abstraction.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Infrastructure.Logging
{
    internal sealed class LoggingCommandHandlerDecorator<TCommand>: ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        private readonly ICommandHandler<TCommand> _commandHandler; 
        private ILogger<LoggingCommandHandlerDecorator<TCommand>> _logger;

        public LoggingCommandHandlerDecorator(ICommandHandler<TCommand> commandHandler, ILogger<LoggingCommandHandlerDecorator<TCommand>> logger)
        {
            _commandHandler = commandHandler;
            _logger = logger;
        }

        public async Task HandleAsync(TCommand command)
        {
            var commandType = command.GetType().Name;

            try
            {
                _logger.LogInformation($"Strated processing {commandType} command.");    
                await _commandHandler.HandleAsync(command);
                _logger.LogInformation($"Finishing processing {commandType}  command.");
            }
            catch (Exception)
            {
                _logger.LogError($"Failed to process {commandType} command");
                throw;
            }
        }
    }
}