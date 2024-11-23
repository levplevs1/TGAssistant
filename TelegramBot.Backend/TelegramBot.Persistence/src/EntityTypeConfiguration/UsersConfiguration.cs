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
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(note => note.id_users);
            builder.HasIndex(note => note.id_users).IsUnique();
            builder.Property(note => note.id_telegram);
            builder.Property(note => note.name).HasMaxLength(250);
            builder.Property(note => note.lastname).HasMaxLength(250);
            builder.Property(note => note.username).HasMaxLength(250); 
            builder.Property(note => note.created_at);
        }
    }
}
