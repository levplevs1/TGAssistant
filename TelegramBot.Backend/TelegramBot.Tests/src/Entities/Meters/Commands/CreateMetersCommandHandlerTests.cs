using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Meters.Commands.CreateMeters;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Meters.Common;

namespace TelegramBot.Tests.src.Entities.Meters.Commands
{
    public class CreateMetersCommandHandlerTests : MetersTestCommandBase
    {
        [Fact]
        public async Task CreateMetersCommandHandler_Success()
        {
            var handler = new CreateMetersCommandHandler(Context);
            var id_meter_type = 1;
            var id_users = 1;

            var id_meters = await handler.Handle(
                new CreateMetersCommand
                {
                    id_meter_type = id_meter_type,
                    id_users = id_users
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Meters.SingleOrDefaultAsync(entity =>
               entity.id_meters == id_meters &&
               entity.id_meter_type == id_meter_type &&
               entity.id_users == id_users));
        }
    }
}
