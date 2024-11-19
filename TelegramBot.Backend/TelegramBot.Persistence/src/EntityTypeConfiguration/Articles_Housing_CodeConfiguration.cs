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
    public class Articles_Housing_CodeConfiguration : IEntityTypeConfiguration<Articles_Housing_Code>
    {
        public void Configure(EntityTypeBuilder<Articles_Housing_Code> builder)
        {
            builder.HasKey(note => note.id_articles_housing_code);
            builder.HasIndex(note => note.id_articles_housing_code).IsUnique();
            builder.Property(note => note.articles_housing_code_name).HasMaxLength(250);
            builder.Property(note => note.articles_housing_code_content).HasMaxLength(250);
            builder.Property(note => note.id_housing_and_communal_services);
        }
    }
}
