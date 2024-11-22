using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Education.Commands.CreateEducation;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Education.Common;

namespace TelegramBot.Tests.src.Entities.Education.Commands
{
    public class CreateEducationCommandHandlerTests : EducationTestCommandBase
    {
        [Fact]
        public async Task CreateEducationCommandHandler_Success()
        {
            var handler = new CreateEducationCommandHandler(Context);
            var text_of_request = "Altus";

            var id_education = await handler.Handle(
                new CreateEducationCommand
                {
                    text_of_request = text_of_request
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Education.SingleOrDefaultAsync(entity =>
               entity.id_education == id_education &&
               entity.text_of_request == text_of_request));
        }
    }
}
