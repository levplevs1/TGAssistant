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
    public class Housing_And_Communal_ServicesConfiguration : IEntityTypeConfiguration<Housing_And_Communal_Services>
    {
        public void Configure(EntityTypeBuilder<Housing_And_Communal_Services> builder)
        {
            builder.HasKey(note => note.id_housing_and_communal_services);
            builder.HasIndex(note => note.id_housing_and_communal_services).IsUnique();
            builder.Property(note => note.text_of_request).HasMaxLength(250);
            builder.Property(note => note.created_at);
        }
    }
}
