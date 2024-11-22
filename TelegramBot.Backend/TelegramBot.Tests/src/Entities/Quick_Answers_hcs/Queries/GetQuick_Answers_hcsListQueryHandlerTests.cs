using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Quick_Answers_hcs.Queries.GetQuick_Answers_hcsList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Quick_Answers_hcs.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_hcs.Queries
{
    [Collection("Quick_Answers_hcsQueryCollection")]
    public class GetQuick_Answers_hcsListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetQuick_Answers_hcsListQueryHandlerTests(Quick_Answers_hcsQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetQuick_Answers_hcsListQueryHandler_Success()
        {
            var handler = new GetQuick_Answers_hcsListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetQuick_Answers_hcsListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<Quick_Answers_hcsListVm>();
            result.Quick_Answers_hcs.Count.ShouldBe(4);
        }
    }
}
