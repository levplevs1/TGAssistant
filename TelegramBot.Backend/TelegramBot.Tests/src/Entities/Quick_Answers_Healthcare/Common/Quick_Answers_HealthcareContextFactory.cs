using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Healthcare.Common
{
    public class Quick_Answers_HealthcareContextFactory
    {
        public static int id_quick_answers_healthcare_for_delete = 3;
        public static int id_quick_answers_healthcare_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Quick_Answers_Healthcare.AddRange(
                new Domain.src.Entities.Quick_Answers_Healthcare
                {
                    id_quick_answer_healthcare = 1,
                    quick_answer_healthcare_name = "Alto",
                    id_healthcare = 1
                },

                new Domain.src.Entities.Quick_Answers_Healthcare
                {
                    id_quick_answer_healthcare = 2,
                    quick_answer_healthcare_name = "Delta",
                    id_healthcare = 2
                },

                new Domain.src.Entities.Quick_Answers_Healthcare

                {
                    id_quick_answer_healthcare = id_quick_answers_healthcare_for_delete,
                    quick_answer_healthcare_name = "Omega",
                    id_healthcare = 3
                },

                new Domain.src.Entities.Quick_Answers_Healthcare
                {
                    id_quick_answer_healthcare = id_quick_answers_healthcare_for_update,
                    quick_answer_healthcare_name = "Radan",
                    id_healthcare = 4
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
