using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Model;

namespace Vehicles.API.Infraestructure.EntityConfigurations
{
    class ScheduleEntityTypeConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .UseHiLo("schedule_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.StartTime)
                .IsRequired();

            builder.Property(cb => cb.EndTime)
                .IsRequired();
        }
    }
}
