using Microsoft.EntityFrameworkCore;
using SophieTravelManagement.Infrastructure.EF.Config;
using SophieTravelManagement.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Infrastructure.EF.Context
{
    internal sealed class ReadDbContext:DbContext
    {
        public ReadDbContext(DbContextOptions<ReadDbContext> dbcontext) : base(dbcontext) { }

        public DbSet<TravelerCheckListReadModel> TravelerCheckList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TravelerCheckList");

            var configuration = new ReadConfiguration();
            modelBuilder.ApplyConfiguration<TravelerCheckListReadModel>(configuration);
            modelBuilder.ApplyConfiguration<TravelerItemReadModel>(configuration);
        }
    }
}
