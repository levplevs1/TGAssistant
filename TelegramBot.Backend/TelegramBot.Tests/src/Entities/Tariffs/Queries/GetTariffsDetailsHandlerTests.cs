using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Tariffs.Queries.GetTariffsDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Tariffs.Common;

namespace TelegramBot.Tests.src.Entities.Tariffs.Queries
{
    [Collection("TariffsQueryCollection")]
    public class GetTariffsDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetTariffsDetailsHandlerTests(TariffsQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetTariffsDetailsQueryHandler_Success()
        {
            var handler = new GetTariffsDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetTariffsDetailsQuery
                {
                    id_tariffs = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<TariffsDetailsVm>();
            result.tariff_value.ShouldBe(1);
        }
    }
}
