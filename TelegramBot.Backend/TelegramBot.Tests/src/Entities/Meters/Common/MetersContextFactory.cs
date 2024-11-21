using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Meters.Common
{
    public class MetersContextFactory
    {
        public static int id_meters_for_delete = 3;
        public static int id_meters_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Meters.AddRange(
                new Domain.src.Entities.Meters
                {
                    id_meters = 1,
                    instalition_date = DateTime.Today,
                    last_reading_date = null,
                    id_meter_type = 1,
                    id_users = 1
                },

                new Domain.src.Entities.Meters
                {
                    id_meters = 2,
                    instalition_date = DateTime.Today,
                    last_reading_date = null,
                    id_meter_type = 2,
                    id_users = 2
                },

                new Domain.src.Entities.Meters

                {
                    id_meters = id_meters_for_delete,
                    instalition_date = DateTime.Today,
                    last_reading_date = null,
                    id_meter_type = 3,
                    id_users = 3
                },

                new Domain.src.Entities.Meters
                {
                    id_meters = id_meters_for_update,
                    instalition_date = DateTime.Today,
                    last_reading_date = null,
                    id_meter_type = 4,
                    id_users = 4
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
