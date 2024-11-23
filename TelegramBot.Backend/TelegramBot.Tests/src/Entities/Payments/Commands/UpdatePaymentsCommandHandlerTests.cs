using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Payments.Commands.UpdatePayments;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Payments.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Payments.Commands
{
    public class UpdatePaymentsCommandHandlerTests : PaymentsTestCommandBase
    {
        [Fact]
        public async Task UpdatePaymentsCommandHandler_Success()
        {
            var handler = new UpdatePaymentsCommandHandler(Context);
            var updatedAmount = 20;

            await handler.Handle(new UpdatePaymentsCommand
            {
                id_payments = PaymentsContextFactory.id_payments_for_update,
                amount = updatedAmount
            }, CancellationToken.None);

            Assert.NotNull(await Context.Payments.SingleOrDefaultAsync(entity =>
            entity.id_users == PaymentsContextFactory.id_payments_for_update &&
            entity.amount == updatedAmount));
        }

        [Fact]
        public async Task UpdatePaymentsCommandhandler_FailOnWrongId()
        {
            var handler = new UpdatePaymentsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdatePaymentsCommand
                {
                    id_payments = 5
                },
                CancellationToken.None));
        }
    }
}
