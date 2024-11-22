using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Healthcare.Commands.UpdateHealthcare;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Healthcare.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Healthcare.Commands
{
    public class UpdateHealthcareCommandHandlerTests : HealthcareTestCommandBase
    {
        [Fact]
        public async Task UpdateHealthcareCommandHandler_Success()
        {
            var handler = new UpdateHealthcareCommandHandler(Context);
            var updatedText_of_request = "Malenia";

            await handler.Handle(new UpdateHealthcareCommand
            {
                id_healthcare = HealthcareContextFactory.id_healthcare_for_update,
                text_of_request = updatedText_of_request
            }, CancellationToken.None);

            Assert.NotNull(await Context.Healthcare.SingleOrDefaultAsync(entity =>
            entity.id_healthcare == HealthcareContextFactory.id_healthcare_for_update &&
            entity.text_of_request == updatedText_of_request));
        }

        [Fact]
        public async Task UpdateHealthcareCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateHealthcareCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateHealthcareCommand
                {
                    id_healthcare = 5
                },
                CancellationToken.None));
        }
    }
}
