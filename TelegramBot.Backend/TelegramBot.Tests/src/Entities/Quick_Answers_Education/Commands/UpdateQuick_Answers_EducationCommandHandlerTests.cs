using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.UpdateQuick_Answers_Education;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Quick_Answers_Education.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Education.Commands
{
    public class UpdateQuick_Answers_EducationCommandHandlerTests : Quick_Answers_EducationTestCommandBase
    {
        [Fact]
        public async Task UpdateQuick_Answers_EducationCommandHandler_Success()
        {
            var handler = new UpdateQuick_Answers_EducationCommandHandler(Context);
            var updatedQuick_answer_education_name = "Malenia";

            await handler.Handle(new UpdateQuick_Answers_EducationCommand
            {
                id_quick_answer_education = Quick_Answers_EducationContextFactory.id_quick_answers_education_for_update,
                quick_answer_education_name = updatedQuick_answer_education_name
            }, CancellationToken.None);

            Assert.NotNull(await Context.Quick_Answers_Education.SingleOrDefaultAsync(entity =>
            entity.id_quick_answer_education == Quick_Answers_EducationContextFactory.id_quick_answers_education_for_update &&
            entity.quick_answer_education_name == updatedQuick_answer_education_name));
        }

        [Fact]
        public async Task UpdateQuick_Answers_EducationCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateQuick_Answers_EducationCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateQuick_Answers_EducationCommand
                {
                    id_quick_answer_education = 5
                },
                CancellationToken.None));
        }
    }
}
