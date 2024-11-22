using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Service_Type.Commands.DeleteService_Type;
using TelegramBot.Application.src.Entities.Service_Type.Commands.UpdateService_Type;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Service_Type.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Service_Type.Commands
{
    public class UpdateService_TypeCommandHandlerTests : Service_TypeTestCommandBase
    {
        [Fact]
        public async Task UpdateService_TypeCommandHandler_Success()
        {
            var handler = new UpdateService_TypeCommandHandler(Context);
            var updatedService_type_name = "Altero";

            await handler.Handle(new UpdateService_TypeCommand
            {
                id_service_type = Service_TypeContextFactory.id_service_type_for_update,
                service_type_name = updatedService_type_name
            }, CancellationToken.None);

            Assert.NotNull(await Context.Service_Type.SingleOrDefaultAsync(entity =>
            entity.id_service_type == Service_TypeContextFactory.id_service_type_for_update &&
            entity.service_type_name == updatedService_type_name));
        }

        [Fact]
        public async Task UpdateService_TypeCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateService_TypeCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateService_TypeCommand
                {
                    id_service_type = 5
                },
                CancellationToken.None));
        }
    }
}
