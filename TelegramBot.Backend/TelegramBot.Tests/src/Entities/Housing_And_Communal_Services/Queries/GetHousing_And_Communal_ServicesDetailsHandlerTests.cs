using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Queries.GetHousing_And_Communal_ServicesDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Housing_And_Communal_Services.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Housing_And_Communal_Services.Queries
{
    [Collection("Housing_And_Communal_ServicesQueryCollection")]
    public class GetHousing_And_Communal_ServicesDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetHousing_And_Communal_ServicesDetailsHandlerTests(Housing_And_Communal_ServicesQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetHousing_And_Communal_ServicesDetailsQueryHandler_Success()
        {
            var handler = new GetHousing_And_Communal_ServicesDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetHousing_And_Communal_ServicesDetailsQuery
                {
                    id_housing_and_communal_services = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<Housing_And_Communal_ServicesDetailsVm>();
            result.text_of_request.ShouldBe("Alto");
        }
    }
}
