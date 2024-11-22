using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Meters.Commands.UpdateMeters;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Meters.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Meters.Commands
{
    public class UpdateMetersCommandHandlerTests : MetersTestCommandBase
    {
        [Fact]
        public async Task UpdateMetersCommandHandler_Success()
        {
            var handler = new UpdateMetersCommandHandler(Context);
            var updatedId_users = 1;
            var updatedId_meter_type = 1;

            await handler.Handle(new UpdateMetersCommand
            {
                id_meters = MetersContextFactory.id_meters_for_update,
                id_users = updatedId_users,
                id_meter_type = updatedId_meter_type
            }, CancellationToken.None);

            Assert.NotNull(await Context.Meters.SingleOrDefaultAsync(entity =>
            entity.id_meters == MetersContextFactory.id_meters_for_update &&
            entity.id_users == updatedId_users &&
            entity.id_meter_type == updatedId_meter_type));
        }

        [Fact]
        public async Task UpdateMetersCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateMetersCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateMetersCommand
                {
                    id_meters = 5
                },
                CancellationToken.None));
        }
    }
}
