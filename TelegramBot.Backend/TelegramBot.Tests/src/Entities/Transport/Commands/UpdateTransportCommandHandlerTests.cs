using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Transport.Commands.UpdateTransport;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Transport.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Transport.Commands
{
    public class UpdateTransportCommandHandlerTests : TransportTestCommandBase
    {
        [Fact]
        public async Task UpdateTransportCommandHandler_Success()
        {
            var handler = new UpdateTransportCommandHandler(Context);
            var updatedText_of_request = "Nikolay";

            await handler.Handle(new UpdateTransportCommand
            {
                id_transport = TransportContextFactory.id_transport_for_update,
                text_of_request = updatedText_of_request
            }, CancellationToken.None);

            Assert.NotNull(await Context.Transport.SingleOrDefaultAsync(entity =>
            entity.id_transport == TransportContextFactory.id_transport_for_update &&
            entity.text_of_request == updatedText_of_request));
        }

        [Fact]
        public async Task UpdateTransportCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateTransportCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateTransportCommand
                {
                    id_transport = 5
                },
                CancellationToken.None));
        }
    }
}
