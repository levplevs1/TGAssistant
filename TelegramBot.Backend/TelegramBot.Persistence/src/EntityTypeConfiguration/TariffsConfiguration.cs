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
    public class TariffsConfiguration : IEntityTypeConfiguration<Tariffs>
    {
        public void Configure(EntityTypeBuilder<Tariffs> builder)
        {
            builder.HasKey(note => note.id_tariffs);
            builder.HasIndex(note => note.id_tariffs).IsUnique();
            builder.Property(note => note.effective_date);
            builder.Property(note => note.tariff_value);
            builder.Property(note => note.id_housing_and_communal_services);
            builder.Property(note => note.id_service_type);
            builder.Property(note => note.id_unit_of_tariffs);
        }
    }
}
