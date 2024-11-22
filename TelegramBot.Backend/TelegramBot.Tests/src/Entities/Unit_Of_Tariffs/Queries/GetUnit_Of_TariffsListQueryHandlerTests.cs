using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Queries.GetUnit_Of_TariffsList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Unit_Of_Tariffs.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Unit_Of_Tariffs.Queries
{
    [Collection("Unit_Of_TariffsQueryCollection")]
    public class GetUnit_Of_TariffsListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetUnit_Of_TariffsListQueryHandlerTests(Unit_Of_TariffsQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetUnit_Of_TariffsListQueryHandler_Success()
        {
            var handler = new GetUnit_Of_TariffsListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetUnit_Of_TariffsListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<Unit_Of_TariffsListVm>();
            result.Unit_Of_Tariffs.Count.ShouldBe(4);
        }
    }
}
