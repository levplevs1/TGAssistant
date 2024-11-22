using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Meter_Readings.Queries.GetMeter_ReadingsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Meter_Readings.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Meter_Readings.Queries
{
    [Collection("Meter_ReadingsQueryCollection")]
    public class GetMeter_ReadingsDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetMeter_ReadingsDetailsHandlerTests(Meter_ReadingsQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetMeter_ReadingsDetailsQueryHandler_Success()
        {
            var handler = new GetMeter_ReadingsDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetMeter_ReadingsDetailsQuery
                {
                    id_meter_readings = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<Meter_ReadingsDetailsVm>();
            result.readings_value.ShouldBe("Alto");
        }
    }
}
