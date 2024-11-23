using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Articles_Housing_Code.Queries.GetArticles_Housing_CodeList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Articles_Housing_Code.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Articles_Housing_Code.Queries
{
    [Collection("Articles_Housing_CodeQueryCollection")]
    public class GetArticles_Housing_CodeListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetArticles_Housing_CodeListQueryHandlerTests(Articles_Housing_CodeQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetArticles_Housing_CodeListQueryHandler_Success()
        {
            var handler = new GetArticles_Housing_CodeListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetArticles_Housing_CodeListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<Articles_Housing_CodeListVm>();
            result.Articles_Housing_Code.Count.ShouldBe(4);
        }
    }
}
