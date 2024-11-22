using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Meter_Readings.Commands.CreateMeter_Readings;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Meter_Readings.Common;

namespace TelegramBot.Tests.src.Entities.Meter_Readings.Commands
{
    public class CreateMeter_ReadingsCommandHandlerTests : Meter_ReadingsTestCommandBase
    {
        [Fact]
        public async Task CreateMeter_ReadingsCommandHandler_Success()
        {
            var handler = new CreateMeter_ReadingsCommandHandler(Context);
            var readings_value = "Altus";
            var previos_readings_value = "Torno";
            var id_meters = 1;
            var id_housing_and_communal_services = 1;

            var id_meter_readings = await handler.Handle(
                new CreateMeter_ReadingsCommand
                {
                    readings_value = readings_value,
                    previos_readings_value = previos_readings_value,
                    id_meters = id_meters,
                    id_housing_and_communal_services = id_housing_and_communal_services
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Meter_Readings.SingleOrDefaultAsync(entity =>
               entity.id_meter_readings == id_meter_readings &&
               entity.readings_value == readings_value &&
               entity.previos_readings_value == previos_readings_value &&
               entity.id_meters == id_meters &&
               entity.id_housing_and_communal_services == id_housing_and_communal_services));
        }
    }
}
