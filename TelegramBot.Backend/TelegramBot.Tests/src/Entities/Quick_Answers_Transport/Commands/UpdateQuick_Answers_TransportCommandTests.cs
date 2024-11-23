using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.CreateQuick_Answers_Transport;
using TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.UpdateQuick_Answers_Transport;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Quick_Answers_Transport.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Transport.Commands
{
    public class UpdateQuick_Answers_TransportCommandTests : Quick_Answers_TransportTestCommandBase
    {
        [Fact]
        public async Task UpdateQuick_Answers_TransportCommandHandler_Success()
        {
            var handler = new UpdateQuick_Answers_TransportCommandHandler(Context);
            var updatedQuick_answer_transport_name = "Gojo";

            await handler.Handle(new UpdateQuick_Answers_TransportCommand
            {
                id_quick_answer_transport = Quick_Answers_TransportContextFactory.id_quick_answers_transport_for_update,
                quick_answer_transport_name = updatedQuick_answer_transport_name
            }, CancellationToken.None);

            Assert.NotNull(await Context.Quick_Answers_Transport.SingleOrDefaultAsync(entity =>
            entity.id_quick_answer_transport == Quick_Answers_TransportContextFactory.id_quick_answers_transport_for_update &&
            entity.quick_answer_transport_name == updatedQuick_answer_transport_name));
        }

        [Fact]
        public async Task UpdateQuick_Answers_TransportCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateQuick_Answers_TransportCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateQuick_Answers_TransportCommand
                {
                    id_quick_answer_transport = 5
                },
                CancellationToken.None));
        }
    }
}
