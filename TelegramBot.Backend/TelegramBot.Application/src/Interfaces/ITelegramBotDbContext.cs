using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Domain.src.Entities;

namespace TelegramBot.Application.src.Interfaces
{
    public interface ITelegramBotDbContext
    {
        DbSet<Articles_Housing_Code> Articles_Housing_Code { get; set; }
        DbSet<Education> Education { get; set; }
        DbSet<Healthcare> Healthcare { get; set; }
        DbSet<Housing_And_Communal_Services> Housing_And_Communal_Services { get; set; }
        DbSet<Meter_Readings> Meter_Readings { get; set; }
        DbSet<Meter_Type> Meter_Type { get; set; }
        DbSet<Meters> Meters { get; set; }
        DbSet<Payments_Method> Payments_Method { get; set; }
        DbSet<Payments> Payments { get; set; }
        DbSet<Quick_Answers_Education> Quick_Answers_Education { get; set; }
        DbSet<Quick_Answers_hcs> Quick_Answers_hcs { get; set; }
        DbSet<Quick_Answers_Healthcare> Quick_Answers_Healthcare { get; set; }
        DbSet<Quick_Answers_Transport> Quick_Answers_Transport { get; set; }
        DbSet<Reading_History> Reading_History { get; set; }
        DbSet<Requests> Requests { get; set; }
        DbSet<Service_Type> Service_Type { get; set; }
        DbSet<Tariffs> Tariffs { get; set; }
        DbSet<Transport> Transport { get; set; }
        DbSet<Type_Of_Requests> Type_Of_Requests { get; set; }
        DbSet<Unit_Of_Tariffs> Unit_Of_Tariffs { get; set; }
        DbSet<Users> Users { get; set; }
        DbSet<User_Memory> User_Memory { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
