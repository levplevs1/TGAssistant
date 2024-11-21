using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Payments.Commands.DeletePayments;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Payments.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Payments.Commands
{
    public class DeletePaymentsCommandHandlerTests : PaymentsTestCommandBase
    {
        [Fact]
        public async Task DeletePaymentsCommandHandler_Success()
        {
            var handler = new DeletePaymentsCommandHandler(Context);

            await handler.Handle(new DeletePaymentsCommand
            {
                id_payments = PaymentsContextFactory.id_payments_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Payments.SingleOrDefault(entity =>
            entity.id_payments == PaymentsContextFactory.id_payments_for_delete));
        }

        [Fact]
        public async Task DeletePaymentsCommandHandler_FailOnWrongId()
        {
            var handler = new DeletePaymentsCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeletePaymentsCommand
                {
                    id_payments = 5
                },
                CancellationToken.None));
        }
    }
}
