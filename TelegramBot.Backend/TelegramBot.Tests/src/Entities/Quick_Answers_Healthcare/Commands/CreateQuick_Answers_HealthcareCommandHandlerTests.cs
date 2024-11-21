using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.CreateQuick_Answers_Healthcare;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Quick_Answers_Healthcare.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Healthcare.Commands
{
    public class CreateQuick_Answers_HealthcareCommandHandlerTests : Quick_Answers_HealthcareTestCommandBase
    {
        [Fact]
        public async Task CreateQuick_Answers_HealthcareCommandHandler_Success()
        {
            var handler = new CreateQuick_Answers_HealthcareCommandHandler(Context);
            var id_healthcare = 1;
            var quick_answer_healthcare_name = "Altus";

            var id_quick_answer_healthcare = await handler.Handle(
                new CreateQuick_Answers_HealthcareCommand
                {
                    quick_answer_healthcare_name = quick_answer_healthcare_name,
                    id_healthcare = id_healthcare
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Quick_Answers_Healthcare.SingleOrDefaultAsync(entity =>
               entity.id_quick_answer_healthcare == id_quick_answer_healthcare &&
               entity.quick_answer_healthcare_name == quick_answer_healthcare_name &&
               entity.id_healthcare == id_healthcare));
        }
    }
}
