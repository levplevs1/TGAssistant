using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Type_Of_Requests.Commands.DeleteType_Of_Requests
{
    public class DeleteType_Of_RequestsCommandHandler
        : IRequestHandler<DeleteType_Of_RequestsCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteType_Of_RequestsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteType_Of_RequestsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Type_Of_Requests
                .FindAsync(new object[] { request.id_type_of_requests }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Type_Of_Requests), request.id_type_of_requests);
            }

            _dbContext.Type_Of_Requests.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
