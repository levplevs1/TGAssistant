using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Reading_History.Commands.DeleteReading_History;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Reading_History.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Reading_History.Commands
{
    public class DeleteReading_HistoryCommandHandlerTests : Reading_HistoryTestCommandBase
    {
        [Fact]
        public async Task DeleteReading_HistoryCommandHandler_Success()
        {
            var handler = new DeleteReading_HistoryCommandHandler(Context);

            await handler.Handle(new DeleteReading_HistoryCommand
            {
                id_reading_history = Reading_HistoryContextFactory.id_reading_history_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Reading_History.SingleOrDefault(entity =>
            entity.id_reading_history == Reading_HistoryContextFactory.id_reading_history_for_delete));
        }

        [Fact]
        public async Task DeleteReading_HistoryCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteReading_HistoryCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteReading_HistoryCommand
                {
                    id_reading_history = 5
                },
                CancellationToken.None));
        }
    }
}
