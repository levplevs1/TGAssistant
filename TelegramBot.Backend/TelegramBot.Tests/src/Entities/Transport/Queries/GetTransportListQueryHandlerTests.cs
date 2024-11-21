using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Transport.Queries.GetTransportList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Transport.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Transport.Queries
{
    [Collection("TransportQueryCollection")]
    public class GetTransportListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetTransportListQueryHandlerTests(TransportQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetTransportListQueryHandler_Success()
        {
            var handler = new GetTransportListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetTransportListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<TransportListVm>();
            result.Transport.Count.ShouldBe(4);
        }
    }
}
