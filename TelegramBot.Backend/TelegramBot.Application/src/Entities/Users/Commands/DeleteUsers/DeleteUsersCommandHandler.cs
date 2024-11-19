using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers
{
    public class DeleteUsersCommandHandler
        : IRequestHandler<DeleteUsersCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteUsersCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteUsersCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users
                .FindAsync(new object[] { request.id_users }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Users), request.id_users);
            }

            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
