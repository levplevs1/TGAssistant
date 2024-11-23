using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Meter_Type.Commands.CreateMeter_Type;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Meter_Type.Common;

namespace TelegramBot.Tests.src.Entities.Meter_Type.Commands
{
    public class CreateMeter_TypeCommandHandlerTests : Meter_TypeTestCommandBase
    {
        [Fact]
        public async Task CreateMeter_TypeCommandHandler_Success()
        {
            var handler = new CreateMeter_TypeCommandHandler(Context);
            var meter_type_name = "Malenia";

            var id_meter_type = await handler.Handle(
                new CreateMeter_TypeCommand
                {
                    meter_type_name = meter_type_name
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Meter_Type.SingleOrDefaultAsync(entity =>
               entity.id_meter_type == id_meter_type &&
               entity.meter_type_name == meter_type_name));
        }
    }
}
