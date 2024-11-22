using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.DeleteUnit_Of_Tariffs;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Unit_Of_Tariffs.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Unit_Of_Tariffs.Commands
{
    public class DeleteUnit_Of_TariffsCommandHandlerTests : Unit_Of_TariffsTestCommandBase
    {
        [Fact]
        public async Task DeleteUnit_Of_TariffsCommandHandler_Success()
        {
            var handler = new DeleteUnit_Of_TariffsCommandHandler(Context);

            await handler.Handle(new DeleteUnit_Of_TariffsCommand
            {
                id_unit_of_tariffs = Unit_Of_TariffsContextFactory.id_unit_of_tariffs_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Unit_Of_Tariffs.SingleOrDefault(entity =>
            entity.id_unit_of_tariffs == Unit_Of_TariffsContextFactory.id_unit_of_tariffs_for_delete));
        }

        [Fact]
        public async Task DeleteUnit_Of_TariffsCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteUnit_Of_TariffsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteUnit_Of_TariffsCommand
                {
                    id_unit_of_tariffs = 5
                },
                CancellationToken.None));
        }
    }
}
