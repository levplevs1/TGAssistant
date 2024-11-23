using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Unit_Of_Tariffs.Common
{
    public class Unit_Of_TariffsContextFactory
    {
        public static int id_unit_of_tariffs_for_delete = 3;
        public static int id_unit_of_tariffs_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Unit_Of_Tariffs.AddRange(
                new Domain.src.Entities.Unit_Of_Tariffs
                {
                    id_unit_of_tariffs = 1,
                    unit_of_tariffs_name = "Alto"
                },

                new Domain.src.Entities.Unit_Of_Tariffs
                {
                    id_unit_of_tariffs = 2,
                    unit_of_tariffs_name = "Delta"
                },

                new Domain.src.Entities.Unit_Of_Tariffs

                {
                    id_unit_of_tariffs = id_unit_of_tariffs_for_delete,
                    unit_of_tariffs_name = "Omega"
                },

                new Domain.src.Entities.Unit_Of_Tariffs
                {
                    id_unit_of_tariffs = id_unit_of_tariffs_for_update,
                    unit_of_tariffs_name = "Radan"
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
