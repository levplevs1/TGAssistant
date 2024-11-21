using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Payments_Method.Commands.UpdatePayments_Method
{
    public class UpdatePayments_MethodCommandHandler
        : IRequestHandler<UpdatePayments_MethodCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdatePayments_MethodCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdatePayments_MethodCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Payments_Method.FirstOrDefaultAsync(note =>
                note.id_payments_method == request.id_payments_method, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Payments_Method), request.id_payments_method);
            }

            entity.payments_method_name = request.payments_method_name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
