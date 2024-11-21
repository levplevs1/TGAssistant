using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Payments_Method.Commands.DeletePayments_Method;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Tests.src.Entities.Payments_Method.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Payments_Method.Commands
{
    public class DeletePayments_MethodCommandHandlerTests : Payments_MethodTestCommandBase
    {
        [Fact]
        public async Task DeletePayments_MethodCommandHandler_Success()
        {
            var handler = new DeletePayments_MethodCommandHandler(Context);

            await handler.Handle(new DeletePayments_MethodCommand
            {
                id_payments_method = Payments_MethodContextFactory.id_payments_method_for_delete,

            }, CancellationToken.None);

            Assert.Null(Context.Payments_Method.SingleOrDefault(entity =>
            entity.id_payments_method == Payments_MethodContextFactory.id_payments_method_for_delete));
        }

        [Fact]
        public async Task DeletePayments_MethodCommandHandler_FailOnWrongId()
        {
            var handler = new DeletePayments_MethodCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeletePayments_MethodCommand
                {
                    id_payments_method = 5
                },
                CancellationToken.None));
        }
    }
}
