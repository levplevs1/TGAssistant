using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Type_Of_Requests.Commands.DeleteType_Of_Requests;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Type_Of_Requests.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Type_Of_Requests.Commands
{
    public class DeleteType_Of_RequestsCommandHandlerTests : Type_Of_RequestsTestCommandBase
    {
        [Fact]
        public async Task DeleteType_Of_RequestsCommandHandler_Success()
        {
            var handler = new DeleteType_Of_RequestsCommandHandler(Context);

            await handler.Handle(new DeleteType_Of_RequestsCommand
            {
                id_type_of_requests = Type_Of_RequestsContextFactory.id_type_of_tequests_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Type_Of_Requests.SingleOrDefault(entity =>
            entity.id_type_of_requests == Type_Of_RequestsContextFactory.id_type_of_tequests_for_delete));
        }

        [Fact]
        public async Task DeleteType_Of_RequestsCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteType_Of_RequestsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteType_Of_RequestsCommand
                {
                    id_type_of_requests = 5
                },
                CancellationToken.None));
        }
    }
}
