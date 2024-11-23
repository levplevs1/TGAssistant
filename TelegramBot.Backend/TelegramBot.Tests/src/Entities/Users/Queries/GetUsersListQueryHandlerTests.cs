using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Users.Queries
{
    [Collection("UsersQueryCollection")]
    public class GetUsersListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetUsersListQueryHandlerTests(UsersQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetUsersListQueryHandler_Success()
        {
            var handler = new GetUsersListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetUsersListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<UsersListVm>();
            result.Users.Count.ShouldBe(4);
        }
    }
}
