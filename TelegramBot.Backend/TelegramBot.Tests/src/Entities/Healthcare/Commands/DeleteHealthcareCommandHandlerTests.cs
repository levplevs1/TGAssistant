using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Healthcare.Commands.DeleteHealthcare;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Healthcare.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Healthcare.Commands
{
    public class DeleteHealthcareCommandHandlerTests : HealthcareTestCommandBase
    {
        [Fact]
        public async Task DeleteHealthcareCommandHandler_Success()
        {
            var handler = new DeleteHealthcareCommandHandler(Context);

            await handler.Handle(new DeleteHealthcareCommand
            {
                id_healthcare = HealthcareContextFactory.id_healthcare_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Healthcare.SingleOrDefault(entity =>
            entity.id_healthcare == HealthcareContextFactory.id_healthcare_for_delete));
        }

        [Fact]
        public async Task DeleteHealthcareCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteHealthcareCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteHealthcareCommand
                {
                    id_healthcare = 5
                },
                CancellationToken.None));
        }
    }
}
