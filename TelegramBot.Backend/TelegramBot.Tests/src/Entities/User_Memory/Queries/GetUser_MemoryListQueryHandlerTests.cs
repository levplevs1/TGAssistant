using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.User_Memory.Queries.GetUser_MemoryList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.User_Memory.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.User_Memory.Queries
{
    [Collection("User_MemoryQueryCollection")]
    public class GetUser_MemoryListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetUser_MemoryListQueryHandlerTests(User_MemoryQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetUser_MemoryListQueryHandler_Success()
        {
            var handler = new GetUser_MemoryListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetUser_MemoryListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<User_MemoryListVm>();
            result.User_Memory.Count.ShouldBe(4);
        }
    }
}
