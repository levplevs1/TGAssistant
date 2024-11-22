using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Requests.Commands.CreateRequest;
using TelegramBot.Application.src.Entities.Requests.Commands.CreateRequests;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Requests.Common;

namespace TelegramBot.Tests.src.Entities.Requests.Commands
{
    public class CreateRequestsCommandHandlerTests : RequestsTestCommandBase
    {
        [Fact]
        public async Task CreateRequestsCommandHandler_Success()
        {
            var handler = new CreateRequestsCommandHandler(Context);
            var request_text = "AlterEgo";
            var response = "DeltaForce";
            var id_type_of_requests = 1;
            var id_users = 1;

            var id_requests = await handler.Handle(
                new CreateRequestsCommand
                {
                    request_text = request_text,
                    response = response,
                    id_type_of_requests = id_type_of_requests,
                    id_users = id_users
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Requests.SingleOrDefaultAsync(entity =>
               entity.id_requests == id_requests &&
               entity.request_text == request_text &&
               entity.response == response &&
               entity.id_type_of_requests == id_type_of_requests &&
               entity.id_users == id_users));
        }
    }
}
