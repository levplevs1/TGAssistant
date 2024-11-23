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

namespace TelegramBot.Application.src.Entities.Payments.Commands.UpdatePayments
{
    public class UpdatePaymentsCommandHandler
        : IRequestHandler<UpdatePaymentsCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdatePaymentsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdatePaymentsCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Payments.FirstOrDefaultAsync(note =>
                note.id_payments == request.id_payments, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Payments), request.id_payments);
            }

            entity.amount = request.amount;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
