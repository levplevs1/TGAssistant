using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Payments.Commands.DeletePayments
{
    public class DeletePaymentsCommandHandler
        : IRequestHandler<DeletePaymentsCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeletePaymentsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeletePaymentsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Payments
                .FindAsync(new object[] { request.id_payments }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Payments), request.id_payments);
            }

            _dbContext.Payments.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
