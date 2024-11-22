using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Education.Commands.UpdateEducation;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Education.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Education.Commands
{
    public class UpdateEducationCommandHandlerTests : EducationTestCommandBase
    {
        [Fact]
        public async Task UpdateEducationCommandHandler_Success()
        {
            var handler = new UpdateEducationCommandHandler(Context);
            var updatedText_of_request = "Malenia";
            var updatedLastname = "Romanov";
            var updatedUsername = "Tsar";

            await handler.Handle(new UpdateEducationCommand
            {
                id_education = EducationContextFactory.id_education_for_update,
                text_of_request = updatedText_of_request
            }, CancellationToken.None);

            Assert.NotNull(await Context.Education.SingleOrDefaultAsync(entity =>
            entity.id_education == EducationContextFactory.id_education_for_update &&
            entity.text_of_request == updatedText_of_request));
        }

        [Fact]
        public async Task UpdateEducationCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateEducationCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateEducationCommand
                {
                    id_education = 5
                },
                CancellationToken.None));
        }
    }
}
