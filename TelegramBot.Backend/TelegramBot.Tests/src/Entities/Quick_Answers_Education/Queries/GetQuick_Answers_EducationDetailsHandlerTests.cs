using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Quick_Answers_Education.Queries.GetQuick_Answers_EducationDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Quick_Answers_Education.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Education.Queries
{
    [Collection("Quick_Answers_EducationQueryCollection")]
    public class GetQuick_Answers_EducationDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetQuick_Answers_EducationDetailsHandlerTests(Quick_Answers_EducationQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetQuick_Answers_EducationDetailsQueryHandler_Success()
        {
            var handler = new GetQuick_Answers_EducationDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetQuick_Answers_EducationDetailsQuery
                {
                    id_quick_answer_education = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<Quick_Answers_EducationDetailsVm>();
            result.quick_answer_education_name.ShouldBe("Alto");
        }
    }
}
