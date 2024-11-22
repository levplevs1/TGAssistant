using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Requests.Commands.DeleteRequests;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Requests.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Requests.Commands
{
    public class DeleteRequestsCommandHandlerTests : RequestsTestCommandBase
    {
        [Fact]
        public async Task DeleteRequestsCommandHandler_Success()
        {
            var handler = new DeleteRequestsCommandHandler(Context);

            await handler.Handle(new DeleteRequestsCommand
            {
                id_requests = RequestsContextFactory.id_requests_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Requests.SingleOrDefault(entity =>
            entity.id_requests == RequestsContextFactory.id_requests_for_delete));
        }

        [Fact]
        public async Task DeleteRequestsCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteRequestsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteRequestsCommand
                {
                    id_requests = 5
                },
                CancellationToken.None));
        }
    }
}
