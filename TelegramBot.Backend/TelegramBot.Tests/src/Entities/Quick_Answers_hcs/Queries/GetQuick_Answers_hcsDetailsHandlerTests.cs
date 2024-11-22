using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Quick_Answers_hcs.Queries.GetQuick_Answers_hcsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Quick_Answers_hcs.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_hcs.Queries
{
    [Collection("Quick_Answers_hcsQueryCollection")]
    public class GetQuick_Answers_hcsDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetQuick_Answers_hcsDetailsHandlerTests(Quick_Answers_hcsQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetQuick_Answers_hcsDetailsQueryHandler_Success()
        {
            var handler = new GetQuick_Answers_hcsDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetQuick_Answers_hcsDetailsQuery
                {
                    id_quick_answers_hcs = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<Quick_Answers_hcsDetailsVm>();
            result.quick_answers_hcs_name.ShouldBe("Alto");
        }
    }
}
