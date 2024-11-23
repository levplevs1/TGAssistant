using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Quick_Answers_Education.Queries.GetQuick_Answers_EducationList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Quick_Answers_Education.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Education.Queries
{
    [Collection("Quick_Answers_EducationQueryCollection")]
    public class GetQuick_Answers_EducationListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetQuick_Answers_EducationListQueryHandlerTests(Quick_Answers_EducationQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetQuick_Answers_EducationListQueryHandler_Success()
        {
            var handler = new GetQuick_Answers_EducationListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetQuick_Answers_EducationListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<Quick_Answers_EducationListVm>();
            result.Quick_Answers_Education.Count.ShouldBe(4);
        }
    }
}
