using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Type_Of_Requests.Queries.GetType_Of_RequestsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Type_Of_Requests.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Type_Of_Requests.Queries
{
    [Collection("Type_Of_RequestsQueryCollection")]
    public class GetType_Of_RequestsDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetType_Of_RequestsDetailsHandlerTests(Type_Of_RequestsQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetType_Of_RequestsDetailsQueryHandler_Success()
        {
            var handler = new GetType_Of_RequestsDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetType_Of_RequestsDetailsQuery
                {
                    id_type_of_requests = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<Type_Of_RequestsDetailsVm>();
            result.id_transport.ShouldBe(1);
        }

        [Fact]
        public async Task GetType_Of_RequestsDetailsQueryHandler_Null()
        {
            var handler = new GetType_Of_RequestsDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetType_Of_RequestsDetailsQuery
                {
                    id_type_of_requests = 2
                },
                CancellationToken.None);

            result.ShouldBeOfType<Type_Of_RequestsDetailsVm>();
            result.id_transport.ShouldBe(null);
        }
    }
}
