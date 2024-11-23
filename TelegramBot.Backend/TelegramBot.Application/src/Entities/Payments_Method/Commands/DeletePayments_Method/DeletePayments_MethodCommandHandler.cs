using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Payments_Method.Commands.DeletePayments_Method
{
    public class DeletePayments_MethodCommandHandler
        : IRequestHandler<DeletePayments_MethodCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeletePayments_MethodCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeletePayments_MethodCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Payments_Method
                .FindAsync(new object[] { request.id_payments_method }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Payments_Method), request.id_payments_method);
            }

            _dbContext.Payments_Method.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
