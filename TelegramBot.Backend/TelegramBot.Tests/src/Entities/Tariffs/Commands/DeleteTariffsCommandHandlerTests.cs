using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Tariffs.Commands.DeleteTariffs;
using TelegramBot.Tests.src.Entities.Tariffs.Common;

namespace TelegramBot.Tests.src.Entities.Tariffs.Commands
{
    public class DeleteTariffsCommandHandlerTests : TariffsTestCommandBase
    {
        [Fact]
        public async Task DeleteTariffsCommandHandler_Success()
        {
            var handler = new DeleteTariffsCommandHandler(Context);

            await handler.Handle(new DeleteTariffsCommand
            {
                id_tariffs = TariffsContextFactory.id_tariffs_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Tariffs.SingleOrDefault(entity =>
            entity.id_tariffs == TariffsContextFactory.id_tariffs_for_delete));
        }

        [Fact]
        public async Task DeleteTariffsCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteTariffsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteTariffsCommand
                {
                    id_tariffs = 5
                },
                CancellationToken.None));
        }
    }
}
