using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Requests.Queries.GetRequestList;
using TelegramBot.Application.src.Entities.Requests.Queries.GetRequestsList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Requests.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Requests.Queries
{
    [Collection("RequestsQueryCollection")]
    public class GetRequestsListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetRequestsListQueryHandlerTests(RequestsQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetRequestsListQueryHandler_Success()
        {
            var handler = new GetRequestsListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetRequestsListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<RequestsListVm>();
            result.Requests.Count.ShouldBe(4);
        }
    }
}
