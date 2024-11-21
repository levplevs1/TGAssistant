using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.UpdateQuick_Answers_Healthcare;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Quick_Answers_Healthcare.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Healthcare.Commands
{
    public class UpdateQuick_Answers_HealthcareCommandHandlerTests : Quick_Answers_HealthcareTestCommandBase
    {
        [Fact]
        public async Task UpdateQuick_Answers_HealthcareCommandHandler_Success()
        {
            var handler = new UpdateQuick_Answers_HealthcareCommandHandler(Context);
            var updatedQuick_answer_healthcare_name = "Malenia";

            await handler.Handle(new UpdateQuick_Answers_HealthcareCommand
            {
                id_quick_answer_healthcare = Quick_Answers_HealthcareContextFactory.id_quick_answers_healthcare_for_update,
                quick_answer_healthcare_name = updatedQuick_answer_healthcare_name
            }, CancellationToken.None);

            Assert.NotNull(await Context.Quick_Answers_Healthcare.SingleOrDefaultAsync(entity =>
            entity.id_quick_answer_healthcare == Quick_Answers_HealthcareContextFactory.id_quick_answers_healthcare_for_update &&
            entity.quick_answer_healthcare_name == updatedQuick_answer_healthcare_name));
        }

        [Fact]
        public async Task UpdateQuick_Answers_HealthcareCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateQuick_Answers_HealthcareCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateQuick_Answers_HealthcareCommand
                {
                    id_quick_answer_healthcare = 5
                },
                CancellationToken.None));
        }
    }
}
