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
    public class Reading_HistoryConfiguration : IEntityTypeConfiguration<Reading_History>
    {
        public void Configure(EntityTypeBuilder<Reading_History> builder)
        {
            builder.HasKey(note => note.id_reading_history);
            builder.HasIndex(note => note.id_reading_history).IsUnique();
            builder.Property(note => note.reading_date);
            builder.Property(note => note.reading_value).HasMaxLength(250);
            builder.Property(note => note.id_meters);
            builder.Property(note => note.id_housing_and_communal_services);
        }
    }
}
