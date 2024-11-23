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
    public class MetersConfiguration : IEntityTypeConfiguration<Meters>
    {
        public void Configure(EntityTypeBuilder<Meters> builder)
        {
            builder.HasKey(note => note.id_meters);
            builder.HasIndex(note => note.id_meters).IsUnique();
            builder.Property(note => note.instalition_date);
            builder.Property(note => note.last_reading_date);
            builder.Property(note => note.id_meter_type);
            builder.Property(note => note.id_users);
        }
    }
}
