using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Users.Commands
{
    public class CreateUsersCommandHandlerTests : UsersTestCommandBase
    {
        [Fact]
        public async Task CreateUsersCommandHandler_Success()
        {
            var handler = new CreateUsersCommandHandler(Context);
            var id_telegram = 1;
            var name = "Ivan";
            var lastname = "Ivanov";
            var username = "Ivanushka";

            var id_users = await handler.Handle(
                new CreateUsersCommand
                {
                    id_telegram = id_telegram,
                    name = name,
                    lastname = lastname,
                    username = username
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Users.SingleOrDefaultAsync(entity =>
               entity.id_users == id_users &&
               entity.id_telegram == id_telegram &&
               entity.name == name &&
               entity.lastname == lastname &&
               entity.username == username));
        }
    }
}
