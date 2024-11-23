using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Type_Of_Requests.Common
{
    public class Type_Of_RequestsContextFactory
    {
        public static int id_type_of_tequests_for_delete = 3;
        public static int id_type_of_tequests_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Type_Of_Requests.AddRange(
                new Domain.src.Entities.Type_Of_Requests
                {
                    id_type_of_requests = 1,
                    id_housing_and_communal_services = 1,
                    id_healthcare = 1,
                    id_transport = 1,
                    id_education = 1
                },

                new Domain.src.Entities.Type_Of_Requests
                {
                    id_type_of_requests = 2,
                    id_housing_and_communal_services = null,
                    id_healthcare = null,
                    id_transport = null,
                    id_education = null
                },

                new Domain.src.Entities.Type_Of_Requests

                {
                    id_type_of_requests = id_type_of_tequests_for_delete,
                    id_housing_and_communal_services = 3,
                    id_healthcare = 3,
                    id_transport = 3,
                    id_education = 3
                },

                new Domain.src.Entities.Type_Of_Requests
                {
                    id_type_of_requests = id_type_of_tequests_for_update,
                    id_housing_and_communal_services = 4,
                    id_healthcare = 4,
                    id_transport = 4,
                    id_education = 4
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
