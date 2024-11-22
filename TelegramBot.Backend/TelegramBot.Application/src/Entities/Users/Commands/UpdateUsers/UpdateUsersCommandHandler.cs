using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers
{
    public class UpdateUsersCommandHandler
        : IRequestHandler<UpdateUsersCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateUsersCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateUsersCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Users.FirstOrDefaultAsync(note =>
                note.id_users == request.id_users, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Users), request.id_users);
            }

            entity.name = request.name;
            entity.lastname = request.lastname;
            entity.username = request.username;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
