using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Requests.Common
{
    public class RequestsContextFactory
    {
        public static int id_requests_for_delete = 3;
        public static int id_requests_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Requests.AddRange(
                new Domain.src.Entities.Requests
                {
                    id_requests = 1,
                    request_text = "Alto",
                    response = "Digma",
                    created_at = DateTime.Today,
                    id_type_of_requests = 1,
                    id_users = 1
                },

                new Domain.src.Entities.Requests
                {
                    id_requests = 2,
                    request_text = "Delta",
                    response = "Pegasus",
                    created_at = DateTime.Today,
                    id_type_of_requests = 2,
                    id_users = 2
                },

                new Domain.src.Entities.Requests

                {
                    id_requests = id_requests_for_delete,
                    request_text = "Omega",
                    response = "Corner",
                    created_at = DateTime.Today,
                    id_type_of_requests = 3,
                    id_users = 3
                },

                new Domain.src.Entities.Requests
                {
                    id_requests = id_requests_for_update,
                    request_text = "Radan",
                    response = "Fura",
                    created_at = DateTime.Today,
                    id_type_of_requests = 4,
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
