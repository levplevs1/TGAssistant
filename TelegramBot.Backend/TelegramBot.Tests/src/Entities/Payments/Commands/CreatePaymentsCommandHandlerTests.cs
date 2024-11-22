using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Payments.Commands.CreatePayments;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Payments.Common;

namespace TelegramBot.Tests.src.Entities.Payments.Commands
{
    public class CreatePaymentsCommandHandlerTests : PaymentsTestCommandBase
    {
        [Fact]
        public async Task CreatePaymentsCommandHandler_Success()
        {
            var handler = new CreatePaymentsCommandHandler(Context);
            var amount = 1;
            var id_users = 1;
            var id_service_type = 1;
            var id_payments_method = 1;

            var id_payments = await handler.Handle(
                new CreatePaymentsCommand
                {
                    amount = amount,
                    id_users = id_users,
                    id_service_type = id_service_type,
                    id_payments_method = id_payments_method
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Payments.SingleOrDefaultAsync(entity =>
               entity.id_payments == id_payments &&
               entity.amount == amount &&
               entity.id_users == id_users &&
               entity.id_service_type == id_service_type &&
               entity.id_payments_method == id_payments_method));
        }
    }
}
