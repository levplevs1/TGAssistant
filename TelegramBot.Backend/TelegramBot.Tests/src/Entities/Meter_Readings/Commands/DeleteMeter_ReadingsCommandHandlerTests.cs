using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Meter_Readings.Commands.DeleteMeter_Readings;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Meter_Readings.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Meter_Readings.Commands
{
    public class DeleteMeter_ReadingsCommandHandlerTests : Meter_ReadingsTestCommandBase
    {
        [Fact]
        public async Task DeleteMeter_ReadingsCommandHandler_Success()
        {
            var handler = new DeleteMeter_ReadingsCommandHandler(Context);

            await handler.Handle(new DeleteMeter_ReadingsCommand
            {
                id_meter_readings = Meter_ReadingsContextFactory.id_meter_readings_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Meter_Readings.SingleOrDefault(entity =>
            entity.id_meter_readings == Meter_ReadingsContextFactory.id_meter_readings_for_delete));
        }

        [Fact]
        public async Task DeleteMeter_ReadingsCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteMeter_ReadingsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteMeter_ReadingsCommand
                {
                    id_meter_readings = 5
                },
                CancellationToken.None));
        }
    }
}
