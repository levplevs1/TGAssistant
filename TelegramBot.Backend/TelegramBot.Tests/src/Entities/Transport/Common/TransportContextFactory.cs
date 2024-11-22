using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Transport.Common
{
    public class TransportContextFactory
    {
        public static int id_transport_for_delete = 3;
        public static int id_transport_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Transport.AddRange(
                new Domain.src.Entities.Transport
                {
                    id_transport = 1,
                    text_of_request = "Alto",
                    created_at = DateTime.Today
                },

                new Domain.src.Entities.Transport
                {
                    id_transport = 2,
                    text_of_request = "Delta",
                    created_at = DateTime.Today
                },

                new Domain.src.Entities.Transport

                {
                    id_transport = id_transport_for_delete,
                    text_of_request = "Omega",
                    created_at = DateTime.Today
                },

                new Domain.src.Entities.Transport
                {
                    id_transport = id_transport_for_update,
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
