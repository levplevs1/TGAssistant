using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.User_Memory.Commands.UpdateUser_Memory;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.User_Memory.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.User_Memory.Commands
{
    public class UpdateUser_MemoryCommandHandlerTests : User_MemoryTestCommandBase
    {
        [Fact]
        public async Task UpdateUser_MemoryCommandHandler_Success()
        {
            var handler = new UpdateUser_MemoryCommandHandler(Context);
            var updatedContent_memory = "Education";

            await handler.Handle(new UpdateUser_MemoryCommand
            {
                id_user_memory = User_MemoryContextFactory.id_user_memory_for_update,
                content_memory = updatedContent_memory
            }, CancellationToken.None);

            Assert.NotNull(await Context.User_Memory.SingleOrDefaultAsync(entity =>
            entity.id_user_memory == User_MemoryContextFactory.id_user_memory_for_update &&
            entity.content_memory == updatedContent_memory));
        }

        [Fact]
        public async Task UpdateUser_MemoryCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateUser_MemoryCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateUser_MemoryCommand
                {
                    id_user_memory = 5
                },
                CancellationToken.None));
        }
    }
}
