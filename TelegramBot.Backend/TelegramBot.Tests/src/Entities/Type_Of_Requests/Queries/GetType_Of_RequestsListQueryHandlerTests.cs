using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Type_Of_Requests.Queries.GetType_Of_RequestsList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Type_Of_Requests.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Type_Of_Requests.Queries
{
    [Collection("Type_Of_RequestsQueryCollection")]
    public class GetType_Of_RequestsListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetType_Of_RequestsListQueryHandlerTests(Type_Of_RequestsQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetType_Of_RequestsListQueryHandler_Success()
        {
            var handler = new GetType_Of_RequestsListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetType_Of_RequestsListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<Type_Of_RequestsListVm>();
            result.Type_Of_Requests.Count.ShouldBe(4);
        }
    }
}
