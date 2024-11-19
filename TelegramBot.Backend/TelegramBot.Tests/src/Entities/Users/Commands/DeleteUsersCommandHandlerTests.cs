using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Users.Commands
{
    public class DeleteUsersCommandHandlerTests : UsersTestCommandBase
    {
        [Fact]
        public async Task DeleteUsersCommandHandler_Success()
        {
            var handler = new DeleteUsersCommandHandler(Context);

            await handler.Handle(new DeleteUsersCommand
            {
                id_users = UsersContextFactory.id_users_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Users.SingleOrDefault(entity =>
            entity.id_users == UsersContextFactory.id_users_for_delete));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteUsersCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteUsersCommand
                {
                    id_users = 5
                },
                CancellationToken.None));
        }
    }
}
