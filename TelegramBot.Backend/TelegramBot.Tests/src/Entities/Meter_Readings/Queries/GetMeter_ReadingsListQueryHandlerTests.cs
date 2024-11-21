using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Meter_Readings.Queries.GetMeter_ReadingsList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Meter_Readings.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Meter_Readings.Queries
{
    [Collection("Meter_ReadingsQueryCollection")]
    public class GetMeter_ReadingsListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetMeter_ReadingsListQueryHandlerTests(Meter_ReadingsQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetMeter_ReadingsListQueryHandler_Success()
        {
            var handler = new GetMeter_ReadingsListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetMeter_ReadingsListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<Meter_ReadingsListVm>();
            result.Meter_Readings.Count.ShouldBe(4);
        }
    }
}
