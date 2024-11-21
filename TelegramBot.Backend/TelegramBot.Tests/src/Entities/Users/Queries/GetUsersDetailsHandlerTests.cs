using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Users.Queries
{
    [Collection("UsersQueryCollection")]
    public class GetUsersDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetUsersDetailsHandlerTests(UsersQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetUsersDetailsQueryHandler_Success()
        {
            var handler = new GetUsersDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetUsersDetailsQuery
                {
                    id_users = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<UsersDetailsVm>();
            result.name.ShouldBe("Ivan");
        }
    }
}
