using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Meters.Queries.GetMetersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Meters.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Meters.Queries
{
    [Collection("MetersQueryCollection")]
    public class GetMetersDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetMetersDetailsHandlerTests(MetersQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetMetersDetailsQueryHandler_Success()
        {
            var handler = new GetMetersDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetMetersDetailsQuery
                {
                    id_meters = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<MetersDetailsVm>();
            result.id_users.ShouldBe(1);
        }
    }
}
