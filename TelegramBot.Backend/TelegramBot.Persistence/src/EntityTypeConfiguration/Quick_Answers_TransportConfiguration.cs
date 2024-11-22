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
    public class Quick_Answers_TransportConfiguration : IEntityTypeConfiguration<Quick_Answers_Transport>
    {
        public void Configure(EntityTypeBuilder<Quick_Answers_Transport> builder)
        {
            builder.HasKey(note => note.id_quick_answer_transport);
            builder.HasIndex(note => note.id_quick_answer_transport).IsUnique();
            builder.Property(note => note.quick_answer_transport_name).HasMaxLength(250);
            builder.Property(note => note.id_transport);
        }
    }
}
