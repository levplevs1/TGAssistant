using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.CreateQuick_Answers_Education;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Quick_Answers_Education.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Education.Commands
{
    public class CreateQuick_Answers_EducationCommandHandlerTests : Quick_Answers_EducationTestCommandBase
    {
        [Fact]
        public async Task CreateQuick_Answers_EducationCommandHandler_Success()
        {
            var handler = new CreateQuick_Answers_EducationCommandHandler(Context);
            var id_education = 1;
            var quick_answer_education_name = "Altus";

            var id_quick_answer_education = await handler.Handle(
                new CreateQuick_Answers_EducationCommand
                {
                    quick_answer_education_name = quick_answer_education_name,
                    id_education = id_education
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Quick_Answers_Education.SingleOrDefaultAsync(entity =>
               entity.id_quick_answer_education == id_quick_answer_education &&
               entity.quick_answer_education_name == quick_answer_education_name &&
               entity.id_education == id_education));
        }
    }
}
