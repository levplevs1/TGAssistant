using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Reading_History.Common
{
    public class Reading_HistoryContextFactory
    {
        public static int id_reading_history_for_delete = 3;
        public static int id_reading_history_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Reading_History.AddRange(
                new Domain.src.Entities.Reading_History
                {
                    id_reading_history = 1,
                    reading_date = DateTime.Today,
                    reading_value = "Alto",
                    id_housing_and_communal_services = 1,
                    id_meters = 1
                },

                new Domain.src.Entities.Reading_History
                {
                    id_reading_history = 2,
                    reading_date = DateTime.Today,
                    reading_value = "Delta",
                    id_housing_and_communal_services = 2,
                    id_meters = 2
                },

                new Domain.src.Entities.Reading_History

                {
                    id_reading_history = id_reading_history_for_delete,
                    reading_date = DateTime.Today,
                    reading_value = "Omega",
                    id_housing_and_communal_services = 3,
                    id_meters = 3
                },

                new Domain.src.Entities.Reading_History
                {
                    id_reading_history = id_reading_history_for_update,
                    reading_date = DateTime.Today,
                    reading_value = "Radan",
                    id_housing_and_communal_services = 4,
                    id_meters = 4
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
