using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.CreateUnit_Of_Tariffs;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Unit_Of_Tariffs.Common;

namespace TelegramBot.Tests.src.Entities.Unit_Of_Tariffs.Commands
{
    public class CreateUnit_Of_TariffsCommandHandlerTests : Unit_Of_TariffsTestCommandBase
    {
        [Fact]
        public async Task CreateUnit_Of_TariffsCommandHandler_Success()
        {
            var handler = new CreateUnit_Of_TariffsCommandHandler(Context);
            var unit_of_tariffs_name = "Ivan";

            var id_unit_of_tariffs = await handler.Handle(
                new CreateUnit_Of_TariffsCommand
                {
                    unit_of_tariffs_name = unit_of_tariffs_name
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Unit_Of_Tariffs.SingleOrDefaultAsync(entity =>
               entity.id_unit_of_tariffs == id_unit_of_tariffs &&
               entity.unit_of_tariffs_name == unit_of_tariffs_name));
        }
    }
}
