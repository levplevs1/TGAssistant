using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Service_Type.Common
{
    public class Service_TypeContextFactory
    {
        public static int id_service_type_for_delete = 3;
        public static int id_service_type_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Service_Type.AddRange(
                new Domain.src.Entities.Service_Type
                {
                    id_service_type = 1,
                    id_housing_and_communal_services = 1,
                    service_type_name = "Alto"
                },

                new Domain.src.Entities.Service_Type
                {
                    id_service_type = 2,
                    id_housing_and_communal_services = 2,
                    service_type_name = "Delta"
                },

                new Domain.src.Entities.Service_Type

                {
                    id_service_type = id_service_type_for_delete,
                    id_housing_and_communal_services = 3,
                    service_type_name = "Omega"
                },

                new Domain.src.Entities.Service_Type
                {
                    id_service_type = id_service_type_for_update,
                    id_housing_and_communal_services = 4,
                    service_type_name = "Radan"
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
