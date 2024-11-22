using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Articles_Housing_Code.Queries.GetArticles_Housing_CodeDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Articles_Housing_Code.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Articles_Housing_Code.Queries
{
    [Collection("Articles_Housing_CodeQueryCollection")]
    public class GetArticles_Housing_CodeDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetArticles_Housing_CodeDetailsHandlerTests(Articles_Housing_CodeQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetArticles_Housing_CodeDetailsQueryHandler_Success()
        {
            var handler = new GetArticles_Housing_CodeDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetArticles_Housing_CodeDetailsQuery
                {
                    id_articles_housing_code = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<Articles_Housing_CodeDetailsVm>();
            result.articles_housing_code_name.ShouldBe("Ivar");
        }
    }
}
