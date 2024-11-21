using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Queries.GetQuick_Answers_HealthcareList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Quick_Answers_Healthcare.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Healthcare.Queries
{
    [Collection("Quick_Answers_HealthcareQueryCollection")]
    public class GetQuick_Answers_HealthcareListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetQuick_Answers_HealthcareListQueryHandlerTests(Quick_Answers_HealthcareQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetQuick_Answers_HealthcareListQueryHandler_Success()
        {
            var handler = new GetQuick_Answers_HealthcareListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetQuick_Answers_HealthcareListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<Quick_Answers_HealthcareListVm>();
            result.Quick_Answers_Healthcare.Count.ShouldBe(4);
        }
    }
}
