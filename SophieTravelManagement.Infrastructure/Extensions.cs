using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SophieTravelManagement.Application.Services;
using SophieTravelManagement.Infrastructure.EF;
using SophieTravelManagement.Infrastructure.Services;
using SophieTravelManagement.Shared.Abstraction.Command;
using SophieTravelManagement.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSQLDB(configuration);
            services.AddQueries();

            services.AddSingleton<IWeatherService, DumbWeatherService>();

            services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

            return services;
        }
    }
}
