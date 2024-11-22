using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Reading_History.Queries.GetReading_HistoryList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Reading_History.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Reading_History.Queries
{
    [Collection("Reading_HistoryQueryCollection")]
    public class GetReading_HistoryListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetReading_HistoryListQueryHandlerTests(Reading_HistoryQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetReading_HistoryListQueryHandler_Success()
        {
            var handler = new GetReading_HistoryListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetReading_HistoryListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<Reading_HistoryListVm>();
            result.Reading_History.Count.ShouldBe(4);
        }
    }
}
