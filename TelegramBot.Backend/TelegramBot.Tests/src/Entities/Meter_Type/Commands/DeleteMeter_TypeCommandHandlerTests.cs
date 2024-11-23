using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Meter_Type.Commands.DeleteMeter_Type;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Meter_Type.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Meter_Type.Commands
{
    public class DeleteMeter_TypeCommandHandlerTests : Meter_TypeTestCommandBase
    {
        [Fact]
        public async Task DeleteMeter_TypeCommandHandler_Success()
        {
            var handler = new DeleteMeter_TypeCommandHandler(Context);

            await handler.Handle(new DeleteMeter_TypeCommand
            {
                id_meter_type = Meter_TypeContextFactory.id_meter_type_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Meter_Type.SingleOrDefault(entity =>
            entity.id_meter_type == Meter_TypeContextFactory.id_meter_type_for_delete));
        }

        [Fact]
        public async Task DeleteMeter_TypeCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteMeter_TypeCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteMeter_TypeCommand
                {
                    id_meter_type = 5
                },
                CancellationToken.None));
        }
    }
}
