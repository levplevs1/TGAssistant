using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_hcs.Common
{
    public class Quick_Answers_hcsContextFactory
    {
        public static int id_quick_answers_hcs_for_delete = 3;
        public static int id_quick_answers_hcs_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Quick_Answers_hcs.AddRange(
                new Domain.src.Entities.Quick_Answers_hcs
                {
                    id_quick_answers_hcs = 1,
                    quick_answers_hcs_name = "Alto",
                    quick_answers_hcs_content = "Raff",
                    id_housing_and_communal_services = 1
                },

                new Domain.src.Entities.Quick_Answers_hcs
                {
                    id_quick_answers_hcs = 2,
                    quick_answers_hcs_name = "Delta",
                    quick_answers_hcs_content = "Ram",
                    id_housing_and_communal_services = 2
                },

                new Domain.src.Entities.Quick_Answers_hcs

                {
                    id_quick_answers_hcs = id_quick_answers_hcs_for_delete,
                    quick_answers_hcs_name = "Omega",
                    quick_answers_hcs_content = "Marika",
                    id_housing_and_communal_services = 3
                },

                new Domain.src.Entities.Quick_Answers_hcs
                {
                    id_quick_answers_hcs = id_quick_answers_hcs_for_update,
                    quick_answers_hcs_name = "Radan",
                    quick_answers_hcs_content = "Wang",
                    id_housing_and_communal_services = 4
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
