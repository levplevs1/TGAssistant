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
    public class Meter_TypeConfiguration : IEntityTypeConfiguration<Meter_Type>
    {
        public void Configure(EntityTypeBuilder<Meter_Type> builder)
        {
            builder.HasKey(note => note.id_meter_type);
            builder.HasIndex(note => note.id_meter_type).IsUnique();
            builder.Property(note => note.meter_type_name).HasMaxLength(250);
        }
    }
}
