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
    public class Unit_Of_TariffsConfiguration : IEntityTypeConfiguration<Unit_Of_Tariffs>
    {
        public void Configure(EntityTypeBuilder<Unit_Of_Tariffs> builder)
        {
            builder.HasKey(note => note.id_unit_of_tariffs);
            builder.HasIndex(note => note.id_unit_of_tariffs).IsUnique();
            builder.Property(note => note.unit_of_tariffs_name).HasMaxLength(250);
        }
    }
}
