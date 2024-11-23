using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.DeleteQuick_Answers_Transport;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Quick_Answers_Transport.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Transport.Commands
{
    public class DeleteQuick_Answers_TransportCommandTests : Quick_Answers_TransportTestCommandBase
    {
        [Fact]
        public async Task DeleteQuick_Answers_TransportCommandHandler_Success()
        {
            var handler = new DeleteQuick_Answers_TransportCommandHandler(Context);

            await handler.Handle(new DeleteQuick_Answers_TransportCommand
            {
                id_quick_answer_transport = Quick_Answers_TransportContextFactory.id_quick_answers_transport_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Quick_Answers_Transport.SingleOrDefault(entity =>
            entity.id_quick_answer_transport == Quick_Answers_TransportContextFactory.id_quick_answers_transport_for_delete));
        }

        [Fact]
        public async Task DeleteQuick_Answers_TransportCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteQuick_Answers_TransportCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteQuick_Answers_TransportCommand
                {
                    id_quick_answer_transport = 5
                },
                CancellationToken.None));
        }
    }
}
