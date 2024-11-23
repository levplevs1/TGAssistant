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
    public class Type_Of_RequestsConfiguration : IEntityTypeConfiguration<Type_Of_Requests>
    {
        public void Configure(EntityTypeBuilder<Type_Of_Requests> builder)
        {
            builder.HasKey(note => note.id_type_of_requests);
            builder.HasIndex(note => note.id_type_of_requests).IsUnique();
            builder.Property(note => note.id_housing_and_communal_services);
            builder.Property(note => note.id_healthcare);
            builder.Property(note => note.id_transport);
            builder.Property(note => note.id_education);
        }
    }
}
