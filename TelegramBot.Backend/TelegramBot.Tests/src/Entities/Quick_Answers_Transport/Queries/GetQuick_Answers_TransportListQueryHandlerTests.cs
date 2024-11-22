using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Quick_Answers_Transport.Queries.GetQuick_Answers_TransportList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Quick_Answers_Transport.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Transport.Queries
{
    [Collection("Quick_Answers_TransportQueryCollection")]
    public class GetQuick_Answers_TransportListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetQuick_Answers_TransportListQueryHandlerTests(Quick_Answers_TransportQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetQuick_Answers_TransportListQueryHandler_Success()
        {
            var handler = new GetQuick_Answers_TransportListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetQuick_Answers_TransportListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<Quick_Answers_TransportListVm>();
            result.Quick_Answers_Transport.Count.ShouldBe(4);
        }
    }
}
