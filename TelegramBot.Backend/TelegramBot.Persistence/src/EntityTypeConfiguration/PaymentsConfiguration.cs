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
    public class PaymentsConfiguration : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> builder)
        {
            builder.HasKey(note => note.id_payments);
            builder.HasIndex(note => note.id_payments).IsUnique();
            builder.Property(note => note.payments_date);
            builder.Property(note => note.amount);
            builder.Property(note => note.id_users);
            builder.Property(note => note.id_payments_method);
            builder.Property(note => note.id_service_type);
        }
    }
}
