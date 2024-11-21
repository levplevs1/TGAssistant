using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Requests.Commands.UpdateRequests;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Requests.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Requests.Commands
{
    public class UpdateRequestsCommandHandlerTests : RequestsTestCommandBase
    {
        [Fact]
        public async Task UpdateRequestsCommandHandler_Success()
        {
            var handler = new UpdateRequestsCommandHandler(Context);
            var updatedRequest_text = "Snake";
            var updatedResponse = "Daleko";

            await handler.Handle(new UpdateRequestsCommand
            {
                id_requests = RequestsContextFactory.id_requests_for_update,
                request_text = updatedRequest_text,
                response = updatedResponse
            }, CancellationToken.None);

            Assert.NotNull(await Context.Requests.SingleOrDefaultAsync(entity =>
            entity.id_requests == RequestsContextFactory.id_requests_for_update &&
            entity.request_text == updatedRequest_text &&
            entity.response == updatedResponse));
        }

        [Fact]
        public async Task UpdateRequestsCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateRequestsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateRequestsCommand
                {
                    id_requests = 5
                },
                CancellationToken.None));
        }
    }
}
