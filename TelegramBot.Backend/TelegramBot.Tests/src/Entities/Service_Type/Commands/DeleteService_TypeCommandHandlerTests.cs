using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Service_Type.Commands.DeleteService_Type;
using TelegramBot.Tests.src.Entities.Service_Type.Common;

namespace TelegramBot.Tests.src.Entities.Service_Type.Commands
{
    public class DeleteService_TypeCommandHandlerTests : Service_TypeTestCommandBase
    {
        [Fact]
        public async Task DeleteService_TypeCommandHandler_Success()
        {
            var handler = new DeleteService_TypeCommandHandler(Context);

            await handler.Handle(new DeleteService_TypeCommand
            {
                id_service_type = Service_TypeContextFactory.id_service_type_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Service_Type.SingleOrDefault(entity =>
            entity.id_service_type == Service_TypeContextFactory.id_service_type_for_delete));
        }

        [Fact]
        public async Task DeleteService_TypeCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteService_TypeCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteService_TypeCommand
                {
                    id_service_type = 5
                },
                CancellationToken.None));
        }
    }
}
