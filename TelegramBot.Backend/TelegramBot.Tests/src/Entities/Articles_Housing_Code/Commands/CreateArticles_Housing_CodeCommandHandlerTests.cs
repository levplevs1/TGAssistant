using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.CreateArticles_Housing_Code;
using TelegramBot.Tests.src.Entities.Articles_Housing_Code.Common;

namespace TelegramBot.Tests.src.Entities.Articles_Housing_Code.Commands
{
    public class CreateArticles_Housing_CodeCommandHandlerTests : Articles_Housing_CodeTestCommandBase
    {
        [Fact]
        public async Task CreateArticles_Housing_CodeCommandHandler_Success()
        {
            var handler = new CreateArticles_Housing_CodeCommandHandler(Context);
            var id_housing_and_communal_services = 1;
            var articles_housing_code_name = "Ivanov";
            var articles_housing_code_content = "Ivanushka";

            var id_articles_housing_code = await handler.Handle(
                new CreateArticles_Housing_CodeCommand
                {
                    id_housing_and_communal_services = id_housing_and_communal_services,
                    articles_housing_code_name = articles_housing_code_name,
                    articles_housing_code_content = articles_housing_code_content
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Articles_Housing_Code.SingleOrDefaultAsync(entity =>
               entity.id_articles_housing_code == id_articles_housing_code &&
               entity.id_housing_and_communal_services == id_housing_and_communal_services &&
               entity.articles_housing_code_name == articles_housing_code_name &&
               entity.articles_housing_code_content == articles_housing_code_content));
        }
    }
}
