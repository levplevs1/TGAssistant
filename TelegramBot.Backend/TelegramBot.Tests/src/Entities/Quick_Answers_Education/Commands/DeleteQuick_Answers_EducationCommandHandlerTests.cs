using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.DeleteQuick_Answers_Education;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Quick_Answers_Education.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Education.Commands
{
    public class DeleteQuick_Answers_EducationCommandHandlerTests : Quick_Answers_EducationTestCommandBase
    {
        [Fact]
        public async Task DeleteQuick_Answers_EducationCommandHandler_Success()
        {
            var handler = new DeleteQuick_Answers_EducationCommandHandler(Context);

            await handler.Handle(new DeleteQuick_Answers_EducationCommand
            {
                id_quick_answer_education = Quick_Answers_EducationContextFactory.id_quick_answers_education_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Quick_Answers_Education.SingleOrDefault(entity =>
            entity.id_quick_answer_education == Quick_Answers_EducationContextFactory.id_quick_answers_education_for_delete));
        }

        [Fact]
        public async Task DeleteQuick_Answers_EducationCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteQuick_Answers_EducationCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteQuick_Answers_EducationCommand
                {
                    id_quick_answer_education = 5
                },
                CancellationToken.None));
        }
    }
}
