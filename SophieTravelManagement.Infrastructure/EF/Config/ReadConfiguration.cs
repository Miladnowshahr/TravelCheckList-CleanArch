using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SophieTravelManagement.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Infrastructure.EF.Config
{
    internal class ReadConfiguration : IEntityTypeConfiguration<TravelerCheckListReadModel>, IEntityTypeConfiguration<TravelerItemReadModel>
    {
        public void Configure(EntityTypeBuilder<TravelerCheckListReadModel> builder)
        {
            builder.ToTable("TravelerCheckList");
            builder.HasKey(pl => pl.Id);

            builder
                .Property(pl => pl.Destination)
                .HasConversion(l => l.ToString(), l => DestinationReadModel.Create(l));

            builder
                .HasMany(pl => pl.Items)
                .WithOne(pi => pi.TravelerCheckList);
        }

        public void Configure(EntityTypeBuilder<TravelerItemReadModel> builder)
        {
            builder.ToTable("TravelerItems"); 
        }
    }
}
