using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Type_Of_Requests.Commands.UpdateType_Of_Requests;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Type_Of_Requests.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Type_Of_Requests.Commands
{
    public class UpdateType_Of_RequestsCommandHandlerTests : Type_Of_RequestsTestCommandBase
    {
        [Fact]
        public async Task UpdateType_Of_RequestsCommandHandler_Success()
        {
            var handler = new UpdateType_Of_RequestsCommandHandler(Context);
            var updatedHousing_and_communal_services = 1;
            var updatedHealthcare = 1;
            var updatedTransport = 1;
            var updatedEducation = 1;

            await handler.Handle(new UpdateType_Of_RequestsCommand
            {
                id_type_of_requests = Type_Of_RequestsContextFactory.id_type_of_tequests_for_update,
                id_housing_and_communal_services = updatedHousing_and_communal_services,
                id_healthcare = updatedHealthcare,
                id_transport = updatedTransport,
                id_education = updatedEducation
            }, CancellationToken.None);

            Assert.NotNull(await Context.Type_Of_Requests.SingleOrDefaultAsync(entity =>
            entity.id_type_of_requests == Type_Of_RequestsContextFactory.id_type_of_tequests_for_update &&
            entity.id_housing_and_communal_services == updatedHousing_and_communal_services &&
            entity.id_healthcare == updatedHealthcare &&
            entity.id_transport == updatedTransport &&
            entity.id_education == updatedEducation));
        }

        [Fact]
        public async Task UpdateType_Of_RequestsCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateType_Of_RequestsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateType_Of_RequestsCommand
                {
                    id_type_of_requests = 5
                },
                CancellationToken.None));
        }
    }
}
