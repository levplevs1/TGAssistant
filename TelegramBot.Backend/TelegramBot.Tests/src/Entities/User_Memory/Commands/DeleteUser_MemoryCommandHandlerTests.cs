using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.User_Memory.Commands.DeleteUser_Memory;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.User_Memory.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.User_Memory.Commands
{
    public class DeleteUser_MemoryCommandHandlerTests : User_MemoryTestCommandBase
    {
        [Fact]
        public async Task DeleteUser_MemoryCommandHandler_Success()
        {
            var handler = new DeleteUser_MemoryCommandHandler(Context);

            await handler.Handle(new DeleteUser_MemoryCommand
            {
                id_user_memory = User_MemoryContextFactory.id_user_memory_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.User_Memory.SingleOrDefault(entity =>
            entity.id_user_memory == User_MemoryContextFactory.id_user_memory_for_delete));
        }

        [Fact]
        public async Task DeleteUser_MemoryCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteUser_MemoryCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteUser_MemoryCommand
                {
                    id_user_memory = 5
                },
                CancellationToken.None));
        }
    }
}
