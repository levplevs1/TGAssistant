using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Tariffs.Queries.GetTariffsDetails;
using TelegramBot.Application.src.Entities.Tariffs.Queries.GetTariffsList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Tariffs.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Tariffs.Queries
{
    [Collection("TariffsQueryCollection")]
    public class GetTariffsListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetTariffsListQueryHandlerTests(TariffsQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetTariffsListQueryHandler_Success()
        {
            var handler = new GetTariffsListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetTariffsListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<TariffsListVm>();
            result.Tariffs.Count.ShouldBe(4);
        }
    }
}
