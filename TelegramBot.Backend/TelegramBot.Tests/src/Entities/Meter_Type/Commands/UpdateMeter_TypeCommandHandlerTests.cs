using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Meter_Type.Commands.UpdateMeter_Type;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Meter_Type.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Meter_Type.Commands
{
    public class UpdateMeter_TypeCommandHandlerTests : Meter_TypeTestCommandBase
    {
        [Fact]
        public async Task UpdateMeter_TypeCommandHandler_Success()
        {
            var handler = new UpdateMeter_TypeCommandHandler(Context);
            var updatedMeter_type_name = "Tsar";

            await handler.Handle(new UpdateMeter_TypeCommand
            {
                id_meter_type = Meter_TypeContextFactory.id_meter_type_for_update,
                meter_type_name = updatedMeter_type_name
            }, CancellationToken.None);

            Assert.NotNull(await Context.Meter_Type.SingleOrDefaultAsync(entity =>
            entity.id_meter_type == Meter_TypeContextFactory.id_meter_type_for_update &&
            entity.meter_type_name == updatedMeter_type_name));
        }

        [Fact]
        public async Task UpdateMeter_TypeCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateMeter_TypeCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateMeter_TypeCommand
                {
                    id_meter_type = 5
                },
                CancellationToken.None));
        }
    }
}
