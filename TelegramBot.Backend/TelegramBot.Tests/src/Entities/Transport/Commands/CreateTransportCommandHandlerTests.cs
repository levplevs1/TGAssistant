using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Transport.Commands.CreateTransport;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Transport.Common;

namespace TelegramBot.Tests.src.Entities.Transport.Commands
{
    public class CreateTransportCommandHandlerTests : TransportTestCommandBase
    {
        [Fact]
        public async Task CreateTransportCommandHandler_Success()
        {
            var handler = new CreateTransportCommandHandler(Context);
            var text_of_request = "Altus";

            var id_transport = await handler.Handle(
                new CreateTransportCommand
                {
                    text_of_request = text_of_request
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Transport.SingleOrDefaultAsync(entity =>
               entity.id_transport == id_transport &&
               entity.text_of_request == text_of_request));
        }
    }
}
