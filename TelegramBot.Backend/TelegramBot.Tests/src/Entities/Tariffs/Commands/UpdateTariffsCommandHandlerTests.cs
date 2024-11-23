using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Tariffs.Commands.DeleteTariffs;
using TelegramBot.Application.src.Entities.Tariffs.Commands.UpdateTariffs;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Tariffs.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Tariffs.Commands
{
    public class UpdateTariffsCommandHandlerTests : TariffsTestCommandBase
    {
        [Fact]
        public async Task UpdateTariffsCommandHandler_Success()
        {
            var handler = new UpdateTariffsCommandHandler(Context);
            var updatedTariff_value = 10;

            await handler.Handle(new UpdateTariffsCommand
            {
                id_tariffs = TariffsContextFactory.id_tariffs_for_update,
                tariff_value = updatedTariff_value
            }, CancellationToken.None);

            Assert.NotNull(await Context.Tariffs.SingleOrDefaultAsync(entity =>
            entity.id_tariffs == TariffsContextFactory.id_tariffs_for_update &&
            entity.tariff_value == updatedTariff_value));
        }

        [Fact]
        public async Task UpdateUsersCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateTariffsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateTariffsCommand
                {
                    id_tariffs = 5
                },
                CancellationToken.None));
        }
    }
}
