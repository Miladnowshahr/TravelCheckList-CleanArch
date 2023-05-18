using Microsoft.Extensions.DependencyInjection;
using SophieTravelManagement.Domain.Factories;
using SophieTravelManagement.Domain.Policies;
using SophieTravelManagement.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication( this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<ITravelerCheckListFactory, TravelerCheckListFactory>();

            services.Scan(b => b.FromAssemblies(typeof(ITravelerItemsPolicy).Assembly)
                .AddClasses(c => c.AssignableTo<ITravelerItemsPolicy>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            return services;
        }
    }
}
