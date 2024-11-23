using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Articles_Housing_Code.Common
{
    public class Articles_Housing_CodeContextFactory
    {
        public static int id_articles_housing_code_for_delete = 3;
        public static int id_articles_housing_code_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Articles_Housing_Code.AddRange(
                new Domain.src.Entities.Articles_Housing_Code
                {
                    id_articles_housing_code = 1,
                    articles_housing_code_name = "Ivar",
                    articles_housing_code_content = "Ragnarson",
                    id_housing_and_communal_services = 1
                },

                new Domain.src.Entities.Articles_Housing_Code
                {
                    id_articles_housing_code = 2,
                    articles_housing_code_name = "Born",
                    articles_housing_code_content = "Ironside",
                    id_housing_and_communal_services = 2
                },

                new Domain.src.Entities.Articles_Housing_Code

                {
                    id_articles_housing_code = id_articles_housing_code_for_delete,
                    articles_housing_code_name = "Korn",
                    articles_housing_code_content = "Wind",
                    id_housing_and_communal_services = 3
                },

                new Domain.src.Entities.Articles_Housing_Code
                {
                    id_articles_housing_code = id_articles_housing_code_for_update,
                    articles_housing_code_name = "Karn",
                    articles_housing_code_content = "Forge",
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
