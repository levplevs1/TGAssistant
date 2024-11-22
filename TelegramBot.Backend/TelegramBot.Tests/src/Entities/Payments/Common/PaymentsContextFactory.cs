using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Payments.Common
{
    public class PaymentsContextFactory
    {
        public static int id_payments_for_delete = 3;
        public static int id_payments_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Payments.AddRange(
                new Domain.src.Entities.Payments
                {
                    id_payments = 1,
                    payments_date = DateTime.Today,
                    amount = 1,
                    id_users = 1,
                    id_service_type = 1,
                    id_payments_method = 1
                },

                new Domain.src.Entities.Payments
                {
                    id_payments = 2,
                    payments_date = DateTime.Today,
                    amount = 2,
                    id_users = 2,
                    id_service_type = 2,
                    id_payments_method = 2
                },

                new Domain.src.Entities.Payments

                {
                    id_payments = id_payments_for_delete,
                    payments_date = DateTime.Today,
                    amount = 3,
                    id_users = 3,
                    id_service_type = 3,
                    id_payments_method = 3
                },

                new Domain.src.Entities.Payments
                {
                    id_payments = id_payments_for_update,
                    payments_date = DateTime.Today,
                    amount = 4,
                    id_users = 4,
                    id_service_type = 4,
                    id_payments_method = 4
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
