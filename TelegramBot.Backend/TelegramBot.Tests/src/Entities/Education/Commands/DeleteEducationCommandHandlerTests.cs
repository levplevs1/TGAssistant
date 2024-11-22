using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Education.Commands.DeleteEducation;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Education.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Education.Commands
{
    public class DeleteEducationCommandHandlerTests : EducationTestCommandBase
    {
        [Fact]
        public async Task DeleteEducationCommandHandler_Success()
        {
            var handler = new DeleteEducationCommandHandler(Context);

            await handler.Handle(new DeleteEducationCommand
            {
                id_education = EducationContextFactory.id_education_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Education.SingleOrDefault(entity =>
            entity.id_education == EducationContextFactory.id_education_for_delete));
        }

        [Fact]
        public async Task DeleteEducationCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteEducationCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteEducationCommand
                {
                    id_education = 5
                },
                CancellationToken.None));
        }
    }
}
