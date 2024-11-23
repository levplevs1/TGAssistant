using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Meter_Type.Common
{
    public class Meter_TypeContextFactory
    {
        public static int id_meter_type_for_delete = 3;
        public static int id_meter_type_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Meter_Type.AddRange(
                new Domain.src.Entities.Meter_Type
                {
                    id_meter_type = 1,
                    meter_type_name = "Alto"
                },

                new Domain.src.Entities.Meter_Type
                {
                    id_meter_type = 2,
                    meter_type_name = "Delta"
                },

                new Domain.src.Entities.Meter_Type

                {
                    id_meter_type = id_meter_type_for_delete,
                    meter_type_name = "Omega"
                },

                new Domain.src.Entities.Meter_Type
                {
                    id_meter_type = id_meter_type_for_update,
                    meter_type_name = "Radan",
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(TelegramBotDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
