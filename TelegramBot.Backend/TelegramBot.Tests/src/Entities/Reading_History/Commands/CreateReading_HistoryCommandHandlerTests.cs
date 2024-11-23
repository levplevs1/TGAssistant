using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Reading_History.Commands.CreateReading_History;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Reading_History.Common;

namespace TelegramBot.Tests.src.Entities.Reading_History.Commands
{
    public class CreateReading_HistoryCommandHandlerTests : Reading_HistoryTestCommandBase
    {
        [Fact]
        public async Task CreateReading_HistoryCommandHandler_Success()
        {
            var handler = new CreateReading_HistoryCommandHandler(Context);
            var reading_value = "Malenia";
            var id_meters = 1;
            var id_housing_and_communal_services = 1;

            var id_reading_history = await handler.Handle(
                new CreateReading_HistoryCommand
                {
                    reading_value = reading_value,
                    id_meters = id_meters,
                    id_housing_and_communal_services = id_housing_and_communal_services
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Reading_History.SingleOrDefaultAsync(entity =>
               entity.id_reading_history == id_reading_history &&
               entity.reading_value == reading_value &&
               entity.id_meters == id_meters &&
               entity.id_housing_and_communal_services == id_housing_and_communal_services));
        }
    }
}
