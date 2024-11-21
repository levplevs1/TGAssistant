using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.User_Memory.Queries.GetUser_MemoryDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.User_Memory.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.User_Memory.Queries
{
    [Collection("User_MemoryQueryCollection")]
    public class GetUser_MemoryDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetUser_MemoryDetailsHandlerTests(User_MemoryQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetUser_MemoryDetailsQueryHandler_Success()
        {
            var handler = new GetUser_MemoryDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetUser_MemoryDetailsQuery
                {
                    id_user_memory = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<User_MemoryDetailsVm>();
            result.content_memory.ShouldBe("Transport");
        }
    }
}
