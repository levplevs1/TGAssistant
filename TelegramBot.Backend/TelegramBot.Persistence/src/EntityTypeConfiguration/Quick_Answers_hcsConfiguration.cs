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
    public class Quick_Answers_hcsConfiguration : IEntityTypeConfiguration<Quick_Answers_hcs>
    {
        public void Configure(EntityTypeBuilder<Quick_Answers_hcs> builder)
        {
            builder.HasKey(note => note.id_quick_answers_hcs);
            builder.HasIndex(note => note.id_quick_answers_hcs).IsUnique();
            builder.Property(note => note.quick_answers_hcs_name).HasMaxLength(250);
            builder.Property(note => note.quick_answers_hcs_content).HasMaxLength(250);
            builder.Property(note => note.id_housing_and_communal_services);
        }
    }
}
