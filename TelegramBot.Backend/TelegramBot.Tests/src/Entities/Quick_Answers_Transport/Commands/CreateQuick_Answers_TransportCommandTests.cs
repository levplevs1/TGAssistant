using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.CreateQuick_Answers_Transport;
using TelegramBot.Tests.src.Entities.Quick_Answers_Transport.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Transport.Commands
{
    public class CreateQuick_Answers_TransportCommandTests : Quick_Answers_TransportTestCommandBase
    {
        [Fact]
        public async Task CreateQuick_Answers_TransportCommandHandler_Success()
        {
            var handler = new CreateQuick_Answers_TransportCommandHandler(Context);
            var id_transport = 1;
            var quick_answer_transport_name = "Malenia";

            var id_quick_answer_transport = await handler.Handle(
                new CreateQuick_Answers_TransportCommand
                {
                    quick_answer_transport_name = quick_answer_transport_name,
                    id_transport = id_transport
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Quick_Answers_Transport.SingleOrDefaultAsync(entity =>
               entity.id_quick_answer_transport == id_quick_answer_transport &&
               entity.id_transport == id_transport &&
               entity.quick_answer_transport_name == quick_answer_transport_name));
        }
    }
}
