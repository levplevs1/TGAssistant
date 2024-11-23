using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Housing_And_Communal_Services.Common
{
    public class Housing_And_Communal_ServicesContextFactory
    {
        public static int id_housing_and_communal_services_for_delete = 3;
        public static int id_housing_and_communal_services_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Housing_And_Communal_Services.AddRange(
                new Domain.src.Entities.Housing_And_Communal_Services
                {
                    id_housing_and_communal_services = 1,
                    text_of_request = "Alto",
                    created_at = DateTime.Today
                },

                new Domain.src.Entities.Housing_And_Communal_Services
                {
                    id_housing_and_communal_services = 2,
                    text_of_request = "Delta",
                    created_at = DateTime.Today
                },

                new Domain.src.Entities.Housing_And_Communal_Services

                {
                    id_housing_and_communal_services = id_housing_and_communal_services_for_delete,
                    text_of_request = "Omega",
                    created_at = DateTime.Today
                },

                new Domain.src.Entities.Housing_And_Communal_Services
                {
                    id_housing_and_communal_services = id_housing_and_communal_services_for_update,
                    text_of_request = "Radan",
                    created_at = DateTime.Today
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
