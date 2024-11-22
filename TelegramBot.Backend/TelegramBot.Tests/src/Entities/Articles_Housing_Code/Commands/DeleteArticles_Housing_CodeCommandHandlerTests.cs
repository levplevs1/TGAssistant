using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.DeleteArticles_Housing_Code;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Articles_Housing_Code.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Articles_Housing_Code.Commands
{
    public class DeleteArticles_Housing_CodeCommandHandlerTests : Articles_Housing_CodeTestCommandBase
    {
        [Fact]
        public async Task DeleteUsersCommandHandler_Success()
        {
            var handler = new DeleteArticles_Housing_CodeCommandHandler(Context);

            await handler.Handle(new DeleteArticles_Housing_CodeCommand
            {
                id_articles_housing_code = Articles_Housing_CodeContextFactory.id_articles_housing_code_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Articles_Housing_Code.SingleOrDefault(entity =>
            entity.id_articles_housing_code == Articles_Housing_CodeContextFactory.id_articles_housing_code_for_delete));
        }

        [Fact]
        public async Task DeleteArticles_Housing_CodeCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteArticles_Housing_CodeCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteArticles_Housing_CodeCommand
                {
                    id_articles_housing_code = 5
                },
                CancellationToken.None));
        }
    }
}
