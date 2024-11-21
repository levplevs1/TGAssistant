using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Payments_Method.Commands.CreatePayments_Method
{
    public class CreatePayments_MethodCommandHandler
        : IRequestHandler<CreatePayments_MethodCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreatePayments_MethodCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreatePayments_MethodCommand request, CancellationToken cancellationToken)
        {
            var payments_method = new Domain.src.Entities.Payments_Method
            {
                payments_method_name = request.payments_method_name
            };

            await _dbContext.Payments_Method.AddAsync(payments_method, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return payments_method.id_payments_method;
        }
    }
}
