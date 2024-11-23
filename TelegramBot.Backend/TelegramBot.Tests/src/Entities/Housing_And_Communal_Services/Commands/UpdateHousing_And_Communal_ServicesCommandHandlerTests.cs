using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Commands.UpdateHousing_And_Communal_Services;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Housing_And_Communal_Services.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Housing_And_Communal_Services.Commands
{
    public class UpdateHousing_And_Communal_ServicesCommandHandlerTests
        : Housing_And_Communal_ServicesTestCommandBase
    {
        [Fact]
        public async Task UpdateHousing_And_Communal_ServicesCommandHandler_Success()
        {
            var handler = new UpdateHousing_And_Communal_ServicesCommandHandler(Context);
            var updatedText_of_request = "Request";

            await handler.Handle(new UpdateHousing_And_Communal_ServicesCommand
            {
                id_housing_and_communal_services = Housing_And_Communal_ServicesContextFactory.id_housing_and_communal_services_for_update,
                text_of_request = updatedText_of_request
            }, CancellationToken.None);

            Assert.NotNull(await Context.Housing_And_Communal_Services.SingleOrDefaultAsync(entity =>
            entity.id_housing_and_communal_services == Housing_And_Communal_ServicesContextFactory.id_housing_and_communal_services_for_update &&
            entity.text_of_request == updatedText_of_request));
        }
        
        [Fact]
        public async Task UpdateHousing_And_Communal_ServicesCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateHousing_And_Communal_ServicesCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateHousing_And_Communal_ServicesCommand
                {
                    id_housing_and_communal_services = 5
                },
                CancellationToken.None));
        }
    }
}
