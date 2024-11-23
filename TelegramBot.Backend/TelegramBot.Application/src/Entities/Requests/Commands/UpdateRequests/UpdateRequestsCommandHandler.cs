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

namespace TelegramBot.Application.src.Entities.Requests.Commands.UpdateRequests
{
    public class UpdateRequestsCommandHandler
        : IRequestHandler<UpdateRequestsCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateRequestsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateRequestsCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Requests.FirstOrDefaultAsync(note =>
                note.id_requests == request.id_requests, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Requests), request.id_requests);
            }

            entity.request_text = request.request_text;
            entity.response = request.response;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
