using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Meters.Queries.GetMetersList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Meters.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Meters.Queries
{
    [Collection("MetersQueryCollection")]
    public class GetMetersListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetMetersListQueryHandlerTests(MetersQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetMetersListQueryHandler_Success()
        {
            var handler = new GetMetersListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetMetersListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<MetersListVm>();
            result.Meters.Count.ShouldBe(4);
        }
    }
}
