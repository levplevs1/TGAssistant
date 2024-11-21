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

namespace TelegramBot.Application.src.Entities.Transport.Commands.UpdateTransport
{
    public class UpdateTransportCommandHandler
        : IRequestHandler<UpdateTransportCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateTransportCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateTransportCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Transport.FirstOrDefaultAsync(note =>
                note.id_transport == request.id_transport, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Transport), request.id_transport);
            }

            entity.text_of_request = request.text_of_request;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
