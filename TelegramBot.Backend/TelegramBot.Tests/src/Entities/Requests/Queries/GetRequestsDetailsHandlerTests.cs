using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Requests.Queries.GetRequestsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Requests.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Requests.Queries
{
    [Collection("RequestsQueryCollection")]
    public class GetRequestsDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetRequestsDetailsHandlerTests(RequestsQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetRequestsDetailsQueryHandler_Success()
        {
            var handler = new GetRequestsDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetRequestsDetailsQuery
                {
                    id_requests = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<RequestsDetailsVm>();
            result.request_text.ShouldBe("Alto");
        }
    }
}
