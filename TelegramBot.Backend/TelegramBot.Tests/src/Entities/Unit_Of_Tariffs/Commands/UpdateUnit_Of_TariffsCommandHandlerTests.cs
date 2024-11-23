using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.UpdateUnit_Of_Tariffs;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Unit_Of_Tariffs.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Unit_Of_Tariffs.Commands
{
    public class UpdateUnit_Of_TariffsCommandHandlerTests : Unit_Of_TariffsTestCommandBase
    {
        [Fact]
        public async Task UpdateUnit_Of_TariffsCommandHandler_Success()
        {
            var handler = new UpdateUnit_Of_TariffsCommandHandler(Context);
            var updatedUnit_of_tariffs_name = "Nikolay";

            await handler.Handle(new UpdateUnit_Of_TariffsCommand
            {
                id_unit_of_tariffs = Unit_Of_TariffsContextFactory.id_unit_of_tariffs_for_update,
                unit_of_tariffs_name = updatedUnit_of_tariffs_name
            }, CancellationToken.None);

            Assert.NotNull(await Context.Unit_Of_Tariffs.SingleOrDefaultAsync(entity =>
            entity.id_unit_of_tariffs == Unit_Of_TariffsContextFactory.id_unit_of_tariffs_for_update &&
            entity.unit_of_tariffs_name == updatedUnit_of_tariffs_name));
        }

        [Fact]
        public async Task UpdateUnit_Of_TariffsCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateUnit_Of_TariffsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateUnit_Of_TariffsCommand
                {
                    id_unit_of_tariffs = 5
                },
                CancellationToken.None));
        }
    }
}
