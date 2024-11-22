using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Education.Common
{
    public class Quick_Answers_EducationContextFactory
    {
        public static int id_quick_answers_education_for_delete = 3;
        public static int id_quick_answers_education_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Quick_Answers_Education.AddRange(
                new Domain.src.Entities.Quick_Answers_Education
                {
                    id_quick_answer_education = 1,
                    quick_answer_education_name = "Alto",
                    id_education = 1
                },

                new Domain.src.Entities.Quick_Answers_Education
                {
                    id_quick_answer_education = 2,
                    quick_answer_education_name = "Delta",
                    id_education = 2
                },

                new Domain.src.Entities.Quick_Answers_Education

                {
                    id_quick_answer_education = id_quick_answers_education_for_delete,
                    quick_answer_education_name = "Omega",
                    id_education = 3
                },

                new Domain.src.Entities.Quick_Answers_Education
                {
                    id_quick_answer_education = id_quick_answers_education_for_update,
                    quick_answer_education_name = "Radan",
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
