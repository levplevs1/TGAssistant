using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Tariffs.Commands.CreateTariffs;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Tariffs.Common;

namespace TelegramBot.Tests.src.Entities.Tariffs.Commands
{
    public class CreateTariffsCommandHandlerTests : TariffsTestCommandBase
    {
        [Fact]
        public async Task CreateTariffsCommandHandler_Success()
        {
            var handler = new CreateTariffsCommandHandler(Context);
            var id_housing_and_communal_services = 1;
            var id_service_type = 1;
            var id_unit_of_tariffs = 1;
            var tariff_value = 1;

            var id_tariffs = await handler.Handle(
                new CreateTariffsCommand
                {
                    id_housing_and_communal_services = id_housing_and_communal_services,
                    id_service_type = id_service_type,
                    id_unit_of_tariffs = id_unit_of_tariffs,
                    tariff_value = tariff_value
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Tariffs.SingleOrDefaultAsync(entity =>
               entity.id_tariffs == id_tariffs &&
               entity.id_housing_and_communal_services == id_housing_and_communal_services &&
               entity.id_service_type == id_service_type &&
               entity.id_unit_of_tariffs == id_unit_of_tariffs &&
               entity.tariff_value == tariff_value));
        }
    }
}
