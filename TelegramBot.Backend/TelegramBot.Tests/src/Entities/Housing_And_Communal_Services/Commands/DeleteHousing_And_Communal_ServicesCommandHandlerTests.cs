using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Commands.DeleteHousing_And_Communal_Services;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Housing_And_Communal_Services.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Housing_And_Communal_Services.Commands
{
    public class DeleteHousing_And_Communal_ServicesCommandHandlerTests
        : Housing_And_Communal_ServicesTestCommandBase
    {
        [Fact]
        public async Task DeleteHousing_And_Communal_ServicesCommandHandler_Success()
        {
            var handler = new DeleteHousing_And_Communal_ServicesCommandHandler(Context);

            await handler.Handle(new DeleteHousing_And_Communal_ServicesCommand
            {
                id_housing_and_communal_services = Housing_And_Communal_ServicesContextFactory.id_housing_and_communal_services_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Housing_And_Communal_Services.SingleOrDefault(entity =>
            entity.id_housing_and_communal_services == Housing_And_Communal_ServicesContextFactory.id_housing_and_communal_services_for_delete));
        }

        [Fact]
        public async Task DeleteHousing_And_Communal_ServicesCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteHousing_And_Communal_ServicesCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteHousing_And_Communal_ServicesCommand
                {
                    id_housing_and_communal_services = 5
                },
                CancellationToken.None));
        }
    }
}
