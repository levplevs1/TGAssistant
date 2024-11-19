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
    public class Payments_MethodConfiguration : IEntityTypeConfiguration<Payments_Method>
    {
        public void Configure(EntityTypeBuilder<Payments_Method> builder)
        {
            builder.HasKey(note => note.id_payments_method);
            builder.HasIndex(note => note.id_payments_method).IsUnique();
            builder.Property(note => note.payments_method_name).HasMaxLength(250);
        }
    }
}
