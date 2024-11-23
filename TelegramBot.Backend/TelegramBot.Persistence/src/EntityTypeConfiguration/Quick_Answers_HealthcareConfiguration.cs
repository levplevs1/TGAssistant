﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Domain.src.Entities;

namespace TelegramBot.Persistence.src.EntityTypeConfiguration
{
    public class Quick_Answers_HealthcareConfiguration : IEntityTypeConfiguration<Quick_Answers_Healthcare>
    {
        public void Configure(EntityTypeBuilder<Quick_Answers_Healthcare> builder)
        {
            builder.HasKey(note => note.id_quick_answer_healthcare);
            builder.HasIndex(note => note.id_quick_answer_healthcare).IsUnique();
            builder.Property(note => note.quick_answer_healthcare_name).HasMaxLength(250);
            builder.Property(note => note.id_healthcare);
        }
    }
}
