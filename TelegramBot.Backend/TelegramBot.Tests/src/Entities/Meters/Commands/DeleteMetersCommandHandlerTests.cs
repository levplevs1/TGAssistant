using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Meters.Commands.DeleteMeters;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Meters.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Meters.Commands
{
    public class DeleteMetersCommandHandlerTests : MetersTestCommandBase
    {
        [Fact]
        public async Task DeleteMetersCommandHandler_Success()
        {
            var handler = new DeleteMetersCommandHandler(Context);

            await handler.Handle(new DeleteMetersCommand
            {
                id_meters = MetersContextFactory.id_meters_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Meters.SingleOrDefault(entity =>
            entity.id_meters == MetersContextFactory.id_meters_for_delete));
        }

        [Fact]
        public async Task DeleteMetersCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteMetersCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteMetersCommand
                {
                    id_meters = 5
                },
                CancellationToken.None));
        }
    }
}
