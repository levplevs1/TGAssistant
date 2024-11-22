using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Transport.Common
{
    public class Quick_Answers_TransportContextFactory
    {
        public static int id_quick_answers_transport_for_delete = 3;
        public static int id_quick_answers_transport_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Quick_Answers_Transport.AddRange(
                new Domain.src.Entities.Quick_Answers_Transport
                {
                    id_quick_answer_transport = 1,
                    quick_answer_transport_name = "Alto",
                    id_transport = 1
                },

                new Domain.src.Entities.Quick_Answers_Transport
                {
                    id_quick_answer_transport = 2,
                    quick_answer_transport_name = "Delta",
                    id_transport = 2
                },

                new Domain.src.Entities.Quick_Answers_Transport

                {
                    id_quick_answer_transport = id_quick_answers_transport_for_delete,
                    quick_answer_transport_name = "Omega",
                    id_transport = 3
                },

                new Domain.src.Entities.Quick_Answers_Transport
                {
                    id_quick_answer_transport = id_quick_answers_transport_for_update,
                    quick_answer_transport_name = "Radan",
                    id_transport = 4
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
