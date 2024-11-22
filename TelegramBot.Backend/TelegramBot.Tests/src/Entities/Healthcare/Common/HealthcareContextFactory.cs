using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Healthcare.Common
{
    public class HealthcareContextFactory
    {
        public static int id_healthcare_for_delete = 3;
        public static int id_healthcare_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Healthcare.AddRange(
                new Domain.src.Entities.Healthcare
                {
                    id_healthcare = 1,
                    text_of_request = "Alto",
                    created_at = DateTime.Today
                },

                new Domain.src.Entities.Healthcare
                {
                    id_healthcare = 2,
                    text_of_request = "Delta",
                    created_at = DateTime.Today
                },

                new Domain.src.Entities.Healthcare

                {
                    id_healthcare = id_healthcare_for_delete,
                    text_of_request = "Omega",
                    created_at = DateTime.Today
                },

                new Domain.src.Entities.Healthcare
                {
                    id_healthcare = id_healthcare_for_update,
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
