using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Users.Commands
{
    public class UpdateUsersCommandHandlerTests : UsersTestCommandBase
    {
        [Fact]
        public async Task UpdateUsersCommandHandler_Success()
        {
            var handler = new UpdateUsersCommandHandler(Context);
            var updatedName = "Nikolay";
            var updatedLastname = "Romanov";
            var updatedUsername = "Tsar";

            await handler.Handle(new UpdateUsersCommand
            {
                id_users = UsersContextFactory.id_users_for_update,
                name = updatedName,
                lastname = updatedLastname,
                username = updatedUsername
            }, CancellationToken.None);

            Assert.NotNull(await Context.Users.SingleOrDefaultAsync(entity =>
            entity.id_users == UsersContextFactory.id_users_for_update &&
            entity.name == updatedName &&
            entity.lastname == updatedLastname &&
            entity.username == updatedUsername));
        }

        [Fact]
        public async Task UpdateUsersCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateUsersCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateUsersCommand
                {
                    id_users = 5
                },
                CancellationToken.None));
        }
    }
}
