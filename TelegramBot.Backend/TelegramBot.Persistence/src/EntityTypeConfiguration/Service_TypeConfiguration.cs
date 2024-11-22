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
    public class Service_TypeConfiguration : IEntityTypeConfiguration<Service_Type>
    {
        public void Configure(EntityTypeBuilder<Service_Type> builder)
        {
            builder.HasKey(note => note.id_service_type);
            builder.HasIndex(note => note.id_service_type).IsUnique();
            builder.Property(note => note.service_type_name).HasMaxLength(250);
            builder.Property(note => note.id_housing_and_communal_services);
        }
    }
}
