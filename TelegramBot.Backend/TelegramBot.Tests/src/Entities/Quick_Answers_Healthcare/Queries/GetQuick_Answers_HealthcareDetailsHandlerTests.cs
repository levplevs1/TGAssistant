using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Queries.GetQuick_Answers_HealthcareDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Quick_Answers_Healthcare.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Healthcare.Queries
{
    [Collection("Quick_Answers_HealthcareQueryCollection")]
    public class GetQuick_Answers_HealthcareDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetQuick_Answers_HealthcareDetailsHandlerTests(Quick_Answers_HealthcareQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetQuick_Answers_HealthcareDetailsQueryHandler_Success()
        {
            var handler = new GetQuick_Answers_HealthcareDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetQuick_Answers_HealthcareDetailsQuery
                {
                    id_quick_answer_healthcare = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<Quick_Answers_HealthcareDetailsVm>();
            result.quick_answer_healthcare_name.ShouldBe("Alto");
        }
    }
}
