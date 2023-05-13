using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SophieTravelManagement.Application.Services;
using SophieTravelManagement.Domain.Repositories;
using SophieTravelManagement.Infrastructure.EF.Context;
using SophieTravelManagement.Infrastructure.EF.Options;
using SophieTravelManagement.Infrastructure.EF.Repositories;
using SophieTravelManagement.Infrastructure.EF.Services;
using SophieTravelManagement.Shared.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ITravelerCheckListRepository,TravelerCheckListRepository>();
            services.AddScoped<ITravelerCheckListReadService, TravelerCheckListReadService>();

            var options = configuration.GetOptions<DatabaseOptions>("DatabaseConnectionstring");
            services.AddDbContext<ReadDbContext>(ctx => ctx.UseSqlServer(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx => ctx.UseSqlServer(options.ConnectionString));

            return services;

        }
    }
}
