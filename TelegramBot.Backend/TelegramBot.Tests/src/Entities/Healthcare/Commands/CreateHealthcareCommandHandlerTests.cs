using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Healthcare.Commands.CreateHealthcare;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Healthcare.Common;

namespace TelegramBot.Tests.src.Entities.Healthcare.Commands
{
    public class CreateHealthcareCommandHandlerTests : HealthcareTestCommandBase
    {
        [Fact]
        public async Task CreateHealthcareCommandHandler_Success()
        {
            var handler = new CreateHealthcareCommandHandler(Context);
            var text_of_request = "Altus";

            var id_healthcare = await handler.Handle(
                new CreateHealthcareCommand
                {
                    text_of_request = text_of_request
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Healthcare.SingleOrDefaultAsync(entity =>
               entity.id_healthcare == id_healthcare &&
               entity.text_of_request == text_of_request));
        }
    }
}
