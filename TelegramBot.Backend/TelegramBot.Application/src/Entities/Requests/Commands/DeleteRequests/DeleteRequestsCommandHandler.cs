using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Requests.Commands.DeleteRequests
{
    public class DeleteRequestsCommandHandler
        : IRequestHandler<DeleteRequestsCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteRequestsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteRequestsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Requests
                .FindAsync(new object[] { request.id_requests }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Requests), request.id_requests);
            }

            _dbContext.Requests.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
