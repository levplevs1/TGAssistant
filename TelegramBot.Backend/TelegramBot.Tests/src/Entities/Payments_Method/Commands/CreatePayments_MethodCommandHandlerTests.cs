using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Payments_Method.Commands.CreatePayments_Method;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Payments_Method.Common;

namespace TelegramBot.Tests.src.Entities.Payments_Method.Commands
{
    public class CreatePayments_MethodCommandHandlerTests : Payments_MethodTestCommandBase
    {
        [Fact]
        public async Task CreatePayments_MethodCommandHandler_Success()
        {
            var handler = new CreatePayments_MethodCommandHandler(Context);
            var payments_method_name = "Malenia";

            var id_payments_method = await handler.Handle(
                new CreatePayments_MethodCommand
                {
                    payments_method_name = payments_method_name
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Payments_Method.SingleOrDefaultAsync(entity =>
               entity.id_payments_method == id_payments_method &&
               entity.payments_method_name == payments_method_name));
        }
    }
}
