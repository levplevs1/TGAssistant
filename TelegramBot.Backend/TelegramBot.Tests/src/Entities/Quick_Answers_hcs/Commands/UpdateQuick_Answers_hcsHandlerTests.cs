using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.UpdateQuick_Answers_hcs;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Quick_Answers_hcs.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_hcs.Commands
{
    public class UpdateQuick_Answers_hcsHandlerTests : Quick_Answers_hcsTestCommandBase
    {
        [Fact]
        public async Task UpdateQuick_Answers_hcsCommandHandler_Success()
        {
            var handler = new UpdateQuick_Answers_hcsCommandHandler(Context);
            var updatedQuick_answers_hcs_name = "Gorno";
            var updatedQuick_answers_hcs_content = "Altoriso";

            await handler.Handle(new UpdateQuick_Answers_hcsCommand
            {
                id_quick_answers_hcs = Quick_Answers_hcsContextFactory.id_quick_answers_hcs_for_update,
                quick_answers_hcs_name = updatedQuick_answers_hcs_name,
                quick_answers_hcs_content = updatedQuick_answers_hcs_content
            }, CancellationToken.None);

            Assert.NotNull(await Context.Quick_Answers_hcs.SingleOrDefaultAsync(entity =>
            entity.id_quick_answers_hcs == Quick_Answers_hcsContextFactory.id_quick_answers_hcs_for_update &&
            entity.quick_answers_hcs_name == updatedQuick_answers_hcs_name &&
            entity.quick_answers_hcs_content == updatedQuick_answers_hcs_content));
        }

        [Fact]
        public async Task UpdateQuick_Answers_hcsCommandhandler_FailOnWrongId()
        {
            var handler = new UpdateQuick_Answers_hcsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateQuick_Answers_hcsCommand
                {
                    id_quick_answers_hcs = 5
                },
                CancellationToken.None));
        }
    }
}
