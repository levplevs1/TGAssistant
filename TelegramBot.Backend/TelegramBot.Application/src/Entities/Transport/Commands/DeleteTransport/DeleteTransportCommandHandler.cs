using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Transport.Commands.DeleteTransport
{
    public class DeleteTransportCommandHandler
        : IRequestHandler<DeleteTransportCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteTransportCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteTransportCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Transport
                .FindAsync(new object[] { request.id_transport }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Transport), request.id_transport);
            }

            _dbContext.Transport.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
