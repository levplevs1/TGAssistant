using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Transport.Commands.DeleteTransport;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Transport.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Transport.Commands
{
    public class DeleteTransportCommandHandlerTests : TransportTestCommandBase
    {
        [Fact]
        public async Task DeleteTransportCommandHandler_Success()
        {
            var handler = new DeleteTransportCommandHandler(Context);

            await handler.Handle(new DeleteTransportCommand
            {
                id_transport = TransportContextFactory.id_transport_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Transport.SingleOrDefault(entity =>
            entity.id_transport == TransportContextFactory.id_transport_for_delete));
        }

        [Fact]
        public async Task DeleteTransportCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteTransportCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteTransportCommand
                {
                    id_transport = 5
                },
                CancellationToken.None));
        }
    }
}
