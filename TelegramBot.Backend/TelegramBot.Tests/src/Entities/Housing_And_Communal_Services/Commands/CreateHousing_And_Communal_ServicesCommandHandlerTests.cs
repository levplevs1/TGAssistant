using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Commands.CreateHousing_And_Communal_Services;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Housing_And_Communal_Services.Common;

namespace TelegramBot.Tests.src.Entities.Housing_And_Communal_Services.Commands
{
    public class CreateHousing_And_Communal_ServicesCommandHandlerTests
        :Housing_And_Communal_ServicesTestCommandBase
    {
        [Fact]
        public async Task CreateHousing_And_Communal_ServicesCommandHandler_Success()
        {
            var handler = new CreateHousing_And_Communal_ServicesCommandHandler(Context);
            var text_of_request = "Malenia";

            var id_housing_and_communal_services = await handler.Handle(
                new CreateHousing_And_Communal_ServicesCommand
                {
                    text_of_request = text_of_request
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Housing_And_Communal_Services.SingleOrDefaultAsync(entity =>
               entity.id_housing_and_communal_services == id_housing_and_communal_services &&
               entity.text_of_request == text_of_request));
        }
    }
}
