using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Type_Of_Requests.Commands.CreateType_Of_Requests;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Type_Of_Requests.Common;

namespace TelegramBot.Tests.src.Entities.Type_Of_Requests.Commands
{
    public class CreateType_Of_RequestsCommandHandlerTests : Type_Of_RequestsTestCommandBase
    {
        [Fact]
        public async Task CreateType_Of_RequestsCommandHandler_Success()
        {
            var handler = new CreateType_Of_RequestsCommandHandler(Context);
            var id_housing_and_communal_services = 1;
            var id_healthcare = 1;
            var id_transport = 1;
            var id_education = 1;

            var id_type_of_requests = await handler.Handle(
                new CreateType_Of_RequestsCommand
                {
                    id_housing_and_communal_services = id_housing_and_communal_services,
                    id_healthcare = id_healthcare,
                    id_transport = id_transport,
                    id_education = id_education
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Type_Of_Requests.SingleOrDefaultAsync(entity =>
               entity.id_type_of_requests == id_type_of_requests &&
               entity.id_housing_and_communal_services == id_housing_and_communal_services &&
               entity.id_healthcare == id_healthcare &&
               entity.id_transport == id_transport &&
               entity.id_education == id_education));
        }
    }
}
