using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Service_Type.Queries.GetService_TypeList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Service_Type.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Service_Type.Queries
{
    [Collection("Service_TypeQueryCollection")]
    public class GetService_TypeListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetService_TypeListQueryHandlerTests(Service_TypeQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetService_TypeListQueryHandler_Success()
        {
            var handler = new GetService_TypeListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetService_TypeListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<Service_TypeListVm>();
            result.Service_Type.Count.ShouldBe(4);
        }
    }
}
