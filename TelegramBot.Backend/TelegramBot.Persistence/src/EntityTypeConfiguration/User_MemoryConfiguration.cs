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
    public class User_MemoryConfiguration : IEntityTypeConfiguration<User_Memory>
    {
        public void Configure(EntityTypeBuilder<User_Memory> builder)
        {
            builder.HasKey(note => note.id_user_memory);
            builder.HasIndex(note => note.id_user_memory).IsUnique();
            builder.Property(note => note.content_memory).HasMaxLength(250);
            builder.Property(note => note.id_users);
        }
    }
}
