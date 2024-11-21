using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Tariffs.Common
{
    public class TariffsContextFactory
    {
        public static int id_tariffs_for_delete = 3;
        public static int id_tariffs_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Tariffs.AddRange(
                new Domain.src.Entities.Tariffs
                {
                    id_tariffs = 1,
                    id_housing_and_communal_services = 1,
                    id_service_type = 1,
                    id_unit_of_tariffs = 1,
                    tariff_value = 1,
                    effective_date = DateTime.Today
                },

                new Domain.src.Entities.Tariffs
                {
                    id_tariffs = 2,
                    id_housing_and_communal_services = 2,
                    id_service_type = 2,
                    id_unit_of_tariffs = 2,
                    tariff_value = 2,
                    effective_date = DateTime.Today
                },

                new Domain.src.Entities.Tariffs

                {
                    id_tariffs = id_tariffs_for_delete,
                    id_housing_and_communal_services = 3,
                    id_service_type = 3,
                    id_unit_of_tariffs = 3,
                    tariff_value = 3,
                    effective_date = DateTime.Today
                },

                new Domain.src.Entities.Tariffs
                {
                    id_tariffs = id_tariffs_for_update,
                    id_housing_and_communal_services = 4,
                    id_service_type = 4,
                    id_unit_of_tariffs = 4,
                    tariff_value = 4,
                    effective_date = DateTime.Today
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
