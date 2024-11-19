using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Interfaces;
using TelegramBot.Domain.src.Entities;
using TelegramBot.Persistence.src.EntityTypeConfiguration;

namespace TelegramBot.Persistence.src.Data
{
    public class TelegramBotDbContext : DbContext, ITelegramBotDbContext
    {
        public DbSet<Articles_Housing_Code> Articles_Housing_Code { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Healthcare> Healthcare { get; set; }
        public DbSet<Housing_And_Communal_Services> Housing_And_Communal_Services { get; set; }
        public DbSet<Meter_Readings> Meter_Readings { get; set; }
        public DbSet<Meter_Type> Meter_Type { get; set; }
        public DbSet<Meters> Meters { get; set; }
        public DbSet<Payments_Method> Payments_Method { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Quick_Answers_Education> Quick_Answers_Education { get; set; }
        public DbSet<Quick_Answers_hcs> Quick_Answers_hcs { get; set; }
        public DbSet<Quick_Answers_Healthcare> Quick_Answers_Healthcare { get; set; }
        public DbSet<Quick_Answers_Transport> Quick_Answers_Transport { get; set; }
        public DbSet<Reading_History> Reading_History { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<Service_Type> Service_Type { get; set; }
        public DbSet<Tariffs> Tariffs { get; set; }
        public DbSet<Transport> Transport { get; set; }
        public DbSet<Type_Of_Requests> Type_Of_Requests { get; set; }
        public DbSet<Unit_Of_Tariffs> Unit_Of_Tariffs { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<User_Memory> User_Memory { get; set; }

        public TelegramBotDbContext(DbContextOptions<TelegramBotDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new Articles_Housing_CodeConfiguration());
            builder.ApplyConfiguration(new EducationConfiguration());
            builder.ApplyConfiguration(new HealthcareConfiguration());
            builder.ApplyConfiguration(new Housing_And_Communal_ServicesConfiguration());
            builder.ApplyConfiguration(new Meter_ReadingsConfiguration());
            builder.ApplyConfiguration(new Meter_TypeConfiguration());
            builder.ApplyConfiguration(new MetersConfiguration());
            builder.ApplyConfiguration(new Payments_MethodConfiguration());
            builder.ApplyConfiguration(new PaymentsConfiguration());
            builder.ApplyConfiguration(new Quick_Answers_EducationConfiguration());
            builder.ApplyConfiguration(new Quick_Answers_hcsConfiguration());
            builder.ApplyConfiguration(new Quick_Answers_HealthcareConfiguration());
            builder.ApplyConfiguration(new Quick_Answers_TransportConfiguration());
            builder.ApplyConfiguration(new Reading_HistoryConfiguration());
            builder.ApplyConfiguration(new RequestsConfiguration());
            builder.ApplyConfiguration(new Service_TypeConfiguration());
            builder.ApplyConfiguration(new TariffsConfiguration());
            builder.ApplyConfiguration(new TransportConfiguration());
            builder.ApplyConfiguration(new Type_Of_RequestsConfiguration());
            builder.ApplyConfiguration(new Unit_Of_TariffsConfiguration());
            builder.ApplyConfiguration(new User_MemoryConfiguration());
            builder.ApplyConfiguration(new UsersConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
