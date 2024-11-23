using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.DeleteQuick_Answers_hcs;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Quick_Answers_hcs.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_hcs.Commands
{
    public class DeteleQuick_Answers_hcsHandlerTests : Quick_Answers_hcsTestCommandBase
    {
        [Fact]
        public async Task DeleteQuick_Answers_hcsCommandHandler_Success()
        {
            var handler = new DeleteQuick_Answers_hcsCommandHandler(Context);

            await handler.Handle(new DeleteQuick_Answers_hcsCommand
            {
                id_quick_answers_hcs = Quick_Answers_hcsContextFactory.id_quick_answers_hcs_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Quick_Answers_hcs.SingleOrDefault(entity =>
            entity.id_quick_answers_hcs == Quick_Answers_hcsContextFactory.id_quick_answers_hcs_for_delete));
        }

        [Fact]
        public async Task DeleteQuick_Answers_hcsCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteQuick_Answers_hcsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteQuick_Answers_hcsCommand
                {
                    id_quick_answers_hcs = 5
                },
                CancellationToken.None));
        }
    }
}
