using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.User_Memory.Commands.CreateUser_Memory;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.User_Memory.Common;

namespace TelegramBot.Tests.src.Entities.User_Memory.Commands
{
    public class CreateUser_MemoryCommandHandlerTests : User_MemoryTestCommandBase
    {
        [Fact]
        public async Task CreateUser_MemoryCommandHandler_Success()
        {
            var handler = new CreateUser_MemoryCommandHandler(Context);
            var id_users = 1;
            var content_memory = "Ivan";

            var id_user_memory = await handler.Handle(
                new CreateUser_MemoryCommand
                {
                    id_users = id_users,
                    content_memory = content_memory
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.User_Memory.SingleOrDefaultAsync(entity =>
               entity.id_users == id_users &&
               entity.content_memory == content_memory &&
               entity.id_user_memory == id_user_memory));
        }
    }
}
