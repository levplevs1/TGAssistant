using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Reading_History.Commands.UpdateReading_History;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Reading_History.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Reading_History.Commands
{
    public class UpdateReading_HistoryCommandHandlerTests : Reading_HistoryTestCommandBase
    {
        [Fact]
        public async Task UpdateReading_HistoryCommandHandler_Success()
        {
            var handler = new UpdateReading_HistoryCommandHandler(Context);
            var updatedReading_value = "Marika";

            await handler.Handle(new UpdateReading_HistoryCommand
            {
                id_reading_history = Reading_HistoryContextFactory.id_reading_history_for_update,
                reading_value = updatedReading_value
            }, CancellationToken.None);

            Assert.NotNull(await Context.Reading_History.SingleOrDefaultAsync(entity =>
            entity.id_reading_history == Reading_HistoryContextFactory.id_reading_history_for_update &&
            entity.reading_value == updatedReading_value));
        }

        [Fact]
        public async Task UpdateReading_HistoryCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateReading_HistoryCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateReading_HistoryCommand
                {
                    id_reading_history = 5
                },
                CancellationToken.None));
        }
    }
}
