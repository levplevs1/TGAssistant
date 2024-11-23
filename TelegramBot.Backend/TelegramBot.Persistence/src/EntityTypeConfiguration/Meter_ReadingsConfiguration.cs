using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Domain.src.Entities;

namespace TelegramBot.Persistence.src.EntityTypeConfiguration
{
    public class Meter_ReadingsConfiguration : IEntityTypeConfiguration<Meter_Readings>
    {
        public void Configure(EntityTypeBuilder<Meter_Readings> builder)
        {
            builder.HasKey(note => note.id_meter_readings);
            builder.HasIndex(note => note.id_meter_readings).IsUnique();
            builder.Property(note => note.readings_value).HasMaxLength(250);
            builder.Property(note => note.previos_readings_value).HasMaxLength(250);
            builder.Property(note => note.readings_date);
            builder.Property(note => note.id_meters);
            builder.Property(note => note.id_housing_and_communal_services);
        }
    }
}
