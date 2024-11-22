using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Payments_Method.Commands.UpdatePayments_Method;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Tests.src.Entities.Payments_Method.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Payments_Method.Commands
{
    public class UpdatePayments_MethodCommandHandlerTests : Payments_MethodTestCommandBase
    {
        [Fact]
        public async Task UpdatePayments_MethodCommandHandler_Success()
        {
            var handler = new UpdatePayments_MethodCommandHandler(Context);
            var updatedPayments_method_name = "Malenia";

            await handler.Handle(new UpdatePayments_MethodCommand
            {
                id_payments_method = Payments_MethodContextFactory.id_payments_method_for_update,
                payments_method_name = updatedPayments_method_name,
            }, CancellationToken.None);

            Assert.NotNull(await Context.Payments_Method.SingleOrDefaultAsync(entity =>
            entity.id_payments_method == Payments_MethodContextFactory.id_payments_method_for_update &&
            entity.payments_method_name == updatedPayments_method_name));
        }

        [Fact]
        public async Task UpdatePayments_MethodCommandhandler_FailOnWrongId()
        {
            var handler = new UpdatePayments_MethodCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdatePayments_MethodCommand
                {
                    id_payments_method = 5
                },
                CancellationToken.None));
        }
    }
}
