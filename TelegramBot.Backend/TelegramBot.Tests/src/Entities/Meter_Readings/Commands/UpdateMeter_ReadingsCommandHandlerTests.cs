using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Meter_Readings.Commands.UpdateMeter_Readings;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Meter_Readings.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Meter_Readings.Commands
{
    public class UpdateMeter_ReadingsCommandHandlerTests : Meter_ReadingsTestCommandBase
    {
        [Fact]
        public async Task UpdateMeter_ReadingsCommandHandler_Success()
        {
            var handler = new UpdateMeter_ReadingsCommandHandler(Context);
            var updatedReadings_value = "AltusRo";
            var updatedPrevios_readings_value = "Malevak";

            await handler.Handle(new UpdateMeter_ReadingsCommand
            {
                id_meter_readings = Meter_ReadingsContextFactory.id_meter_readings_for_update,
                readings_value = updatedReadings_value,
                previos_readings_value = updatedPrevios_readings_value
            }, CancellationToken.None);

            Assert.NotNull(await Context.Meter_Readings.SingleOrDefaultAsync(entity =>
            entity.id_meter_readings == Meter_ReadingsContextFactory.id_meter_readings_for_update &&
            entity.readings_value == updatedReadings_value &&
            entity.previos_readings_value == updatedPrevios_readings_value));
        }

        [Fact]
        public async Task UpdateMeter_ReadingsCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateMeter_ReadingsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateMeter_ReadingsCommand
                {
                    id_meter_readings = 5
                },
                CancellationToken.None));
        }
    }
}
