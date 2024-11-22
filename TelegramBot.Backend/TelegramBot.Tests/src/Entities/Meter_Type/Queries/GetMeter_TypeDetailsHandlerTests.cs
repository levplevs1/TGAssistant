using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Meter_Type.Queries.GetMeter_TypeDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Meter_Type.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Meter_Type.Queries
{
    [Collection("Meter_TypeQueryCollection")]
    public class GetMeter_TypeDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetMeter_TypeDetailsHandlerTests(Meter_TypeQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetMeter_TypeDetailsQueryHandler_Success()
        {
            var handler = new GetMeter_TypeDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetMeter_TypeDetailsQuery
                {
                    id_meter_type = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<Meter_TypeDetailsVm>();
            result.meter_type_name.ShouldBe("Alto");
        }
    }
}
