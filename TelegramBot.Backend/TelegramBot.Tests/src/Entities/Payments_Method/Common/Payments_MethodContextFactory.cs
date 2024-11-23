using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Payments_Method.Common
{
    public class Payments_MethodContextFactory
    {
        public static int id_payments_method_for_delete = 3;
        public static int id_payments_method_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Payments_Method.AddRange(
                new Domain.src.Entities.Payments_Method
                {
                    id_payments_method = 1,
                    payments_method_name = "Alto"
                },

                new Domain.src.Entities.Payments_Method
                {
                    id_payments_method = 2,
                    payments_method_name = "Delta"
                },

                new Domain.src.Entities.Payments_Method

                {
                    id_payments_method = id_payments_method_for_delete,
                    payments_method_name = "Omega"
                },

                new Domain.src.Entities.Payments_Method
                {
                    id_payments_method = id_payments_method_for_update,
                    payments_method_name = "Radan"
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
