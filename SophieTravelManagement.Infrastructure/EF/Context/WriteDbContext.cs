using Microsoft.EntityFrameworkCore;
using SophieTravelManagement.Infrastructure.EF.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Infrastructure.EF.Context
{
    internal sealed class WriteDbContext:DbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base()
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<TravelerCheckList>(configuration);
            modelBuilder.ApplyConfiguration<TravelerItem>(configuration);
        }
    }
}
