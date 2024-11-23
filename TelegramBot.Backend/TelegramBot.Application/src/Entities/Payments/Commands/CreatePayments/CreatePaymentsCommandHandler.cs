using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Payments.Commands.CreatePayments
{
    public class CreatePaymentsCommandHandler
        : IRequestHandler<CreatePaymentsCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreatePaymentsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreatePaymentsCommand request, CancellationToken cancellationToken)
        {
            var payments = new Domain.src.Entities.Payments
            {
                payments_date = DateTime.Now,
                amount = request.amount,
                id_users = request.id_users,
                id_payments_method = request.id_payments_method,
                id_service_type = request.id_service_type
            };

            await _dbContext.Payments.AddAsync(payments, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return payments.id_payments;
        }
    }
}
