using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Reading_History.Queries.GetReading_HistoryDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Reading_History.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Reading_History.Queries
{
    [Collection("Reading_HistoryQueryCollection")]
    public class GetReading_HistoryDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetReading_HistoryDetailsHandlerTests(Reading_HistoryQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetReading_HistoryDetailsQueryHandler_Success()
        {
            var handler = new GetReading_HistoryDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetReading_HistoryDetailsQuery
                {
                    id_reading_history = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<Reading_HistoryDetailsVm>();
            result.reading_value.ShouldBe("Alto");
        }
    }
}
