using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.UpdateArticles_Housing_Code;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Articles_Housing_Code.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Articles_Housing_Code.Commands
{
    public class UpdateArticles_Housing_CodeCommandHandlerTests : Articles_Housing_CodeTestCommandBase
    {
        [Fact]
        public async Task UpdateArticles_Housing_CodeCommandHandler_Success()
        {
            var handler = new UpdateArticles_Housing_CodeCommandHandler(Context);
            var updatedArticles_housing_code_name = "Nikolay";
            var updatedArticles_housing_code_content = "Romanov";

            await handler.Handle(new UpdateArticles_Housing_CodeCommand
            {
                id_articles_housing_code = Articles_Housing_CodeContextFactory.id_articles_housing_code_for_update,
                articles_housing_code_name = updatedArticles_housing_code_name,
                articles_housing_code_content = updatedArticles_housing_code_content
            }, CancellationToken.None);

            Assert.NotNull(await Context.Articles_Housing_Code.SingleOrDefaultAsync(entity =>
            entity.id_articles_housing_code == Articles_Housing_CodeContextFactory.id_articles_housing_code_for_update &&
            entity.articles_housing_code_name == updatedArticles_housing_code_name &&
            entity.articles_housing_code_content == updatedArticles_housing_code_content));
        }

        [Fact]
        public async Task UpdateArticles_Housing_CodeCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateArticles_Housing_CodeCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateArticles_Housing_CodeCommand
                {
                    id_articles_housing_code = 5
                },
                CancellationToken.None));
        }
    }
}
