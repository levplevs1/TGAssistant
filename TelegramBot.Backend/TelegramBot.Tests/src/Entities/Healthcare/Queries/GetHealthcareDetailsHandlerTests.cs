using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Healthcare.Queries.GetHealthcareDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Healthcare.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Healthcare.Queries
{
    [Collection("HealthcareQueryCollection")]
    public class GetHealthcareDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetHealthcareDetailsHandlerTests(HealthcareQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetHealthcareDetailsQueryHandler_Success()
        {
            var handler = new GetHealthcareDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetHealthcareDetailsQuery
                {
                    id_healthcare = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<HealthcareDetailsVm>();
            result.text_of_request.ShouldBe("Alto");
        }
    }
}
