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
    public class RequestsConfiguration : IEntityTypeConfiguration<Requests>
    {
        public void Configure(EntityTypeBuilder<Requests> builder)
        {
            builder.HasKey(note => note.id_requests);
            builder.HasIndex(note => note.id_requests).IsUnique();
            builder.Property(note => note.request_text).HasMaxLength(250);
            builder.Property(note => note.response).HasMaxLength(250);
            builder.Property(note => note.created_at);
            builder.Property(note => note.id_type_of_requests);
            builder.Property(note => note.id_users);
            
        }
    }
}
