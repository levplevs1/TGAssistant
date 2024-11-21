using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Service_Type.Queries.GetService_TypeDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Service_Type.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Service_Type.Queries
{
    [Collection("Service_TypeQueryCollection")]
    public class GetService_TypeDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetService_TypeDetailsHandlerTests(Service_TypeQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetService_TypeDetailsQueryHandler_Success()
        {
            var handler = new GetService_TypeDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetService_TypeDetailsQuery
                {
                    id_service_type = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<Service_TypeDetailsVm>();
            result.service_type_name.ShouldBe("Alto");
        }
    }
}
