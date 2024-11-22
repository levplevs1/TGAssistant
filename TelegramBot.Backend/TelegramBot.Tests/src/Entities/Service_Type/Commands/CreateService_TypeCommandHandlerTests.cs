using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Service_Type.Commands.CreateService_Type;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Service_Type.Common;

namespace TelegramBot.Tests.src.Entities.Service_Type.Commands
{
    public class CreateService_TypeCommandHandlerTests : Service_TypeTestCommandBase
    {
        [Fact]
        public async Task CreateService_TypeCommandHandler_Success()
        {
            var handler = new CreateService_TypeCommandHandler(Context);
            var id_housing_and_communal_services = 1;
            var service_type_name = "Digma";

            var id_service_type = await handler.Handle(
                new CreateService_TypeCommand
                {
                    id_housing_and_communal_services = id_housing_and_communal_services,
                    service_type_name = service_type_name
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Service_Type.SingleOrDefaultAsync(entity =>
               entity.id_service_type == id_service_type &&
               entity.service_type_name == service_type_name &&
               entity.id_housing_and_communal_services == id_housing_and_communal_services));
        }
    }
}
