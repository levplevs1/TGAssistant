using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Healthcare.Queries.GetHealthcareList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Healthcare.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Healthcare.Queries
{
    [Collection("HealthcareQueryCollection")]
    public class GetHealthcareListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetHealthcareListQueryHandlerTests(HealthcareQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetHealthcareListQueryHandler_Success()
        {
            var handler = new GetHealthcareListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetHealthcareListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<HealthcareListVm>();
            result.Healthcare.Count.ShouldBe(4);
        }
    }
}
