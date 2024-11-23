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
    public class HealthcareConfiguration : IEntityTypeConfiguration<Healthcare>
    {
        public void Configure(EntityTypeBuilder<Healthcare> builder)
        {
            builder.HasKey(note => note.id_healthcare);
            builder.HasIndex(note => note.id_healthcare).IsUnique();
            builder.Property(note => note.text_of_request).HasMaxLength(250);
            builder.Property(note => note.created_at);
        }
    }
}
