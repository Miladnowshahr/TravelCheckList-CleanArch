using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Shared.Services
{
    internal sealed class AppInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public AppInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var dbContexttypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(w => typeof(DbContext).IsAssignableFrom(w) && !w.IsInterface && w != typeof(DbContext));

            using var scope = _serviceProvider.CreateScope();
            foreach (var dbcontextType in dbContexttypes)
            {
                var dbContext = scope.ServiceProvider.GetRequiredService(dbcontextType) as DbContext;
                if (dbContext is null)
                {
                    continue;
                }
                await dbContext.Database.EnsureCreatedAsync(cancellationToken);
            }

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
