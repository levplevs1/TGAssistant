using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Education.Queries.GetEducationList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Education.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Education.Queries
{
    [Collection("EducationQueryCollection")]
    public class GetEducationListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetEducationListQueryHandlerTests(EducationQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetEducationListQueryHandler_Success()
        {
            var handler = new GetEducationListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetEducationListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<EducationListVm>();
            result.Education.Count.ShouldBe(4);
        }
    }
}
