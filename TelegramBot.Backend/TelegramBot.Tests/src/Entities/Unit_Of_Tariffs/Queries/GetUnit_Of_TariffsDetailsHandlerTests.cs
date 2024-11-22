using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Queries.GetUnit_Of_TariffsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Unit_Of_Tariffs.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Unit_Of_Tariffs.Queries
{
    [Collection("Unit_Of_TariffsQueryCollection")]
    public class GetUnit_Of_TariffsDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetUnit_Of_TariffsDetailsHandlerTests(Unit_Of_TariffsQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetUnit_Of_TariffsDetailsQueryHandler_Success()
        {
            var handler = new GetUnit_Of_TariffsDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetUnit_Of_TariffsDetailsQuery
                {
                    id_unit_of_tariffs = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<Unit_Of_TariffsDetailsVm>();
            result.unit_of_tariffs_name.ShouldBe("Alto");
        }
    }
}
