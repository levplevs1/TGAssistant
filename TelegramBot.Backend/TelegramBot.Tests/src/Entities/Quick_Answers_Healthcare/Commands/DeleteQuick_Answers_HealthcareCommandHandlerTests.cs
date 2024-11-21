using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.DeleteQuick_Answers_Healthcare;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Quick_Answers_Healthcare.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Healthcare.Commands
{
    public class DeleteQuick_Answers_HealthcareCommandHandlerTests : Quick_Answers_HealthcareTestCommandBase
    {
        [Fact]
        public async Task DeleteQuick_Answers_HealthcareCommandHandler_Success()
        {
            var handler = new DeleteQuick_Answers_HealthcareCommandHandler(Context);

            await handler.Handle(new DeleteQuick_Answers_HealthcareCommand
            {
                id_quick_answer_healthcare = Quick_Answers_HealthcareContextFactory.id_quick_answers_healthcare_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Quick_Answers_Healthcare.SingleOrDefault(entity =>
            entity.id_quick_answer_healthcare == Quick_Answers_HealthcareContextFactory.id_quick_answers_healthcare_for_delete));
        }

        [Fact]
        public async Task DeleteQuick_Answers_HealthcareCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteQuick_Answers_HealthcareCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteQuick_Answers_HealthcareCommand
                {
                    id_quick_answer_healthcare = 5
                },
                CancellationToken.None));
        }
    }
}
