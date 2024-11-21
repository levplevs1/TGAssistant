using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Meter_Type.Queries.GetMeter_TypeList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Meter_Type.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Meter_Type.Queries
{
    [Collection("Meter_TypeQueryCollection")]
    public class GetMeter_TypeListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetMeter_TypeListQueryHandlerTests(Meter_TypeQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetMeter_TypeListQueryHandler_Success()
        {
            var handler = new GetMeter_TypeListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetMeter_TypeListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<Meter_TypeListVm>();
            result.Meter_Type.Count.ShouldBe(4);
        }
    }
}
