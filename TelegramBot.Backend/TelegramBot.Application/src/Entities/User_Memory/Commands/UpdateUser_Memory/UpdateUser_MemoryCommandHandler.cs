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

namespace TelegramBot.Application.src.Entities.User_Memory.Commands.UpdateUser_Memory
{
    public class UpdateUser_MemoryCommandHandler
        : IRequestHandler<UpdateUser_MemoryCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateUser_MemoryCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateUser_MemoryCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.User_Memory.FirstOrDefaultAsync(note =>
                note.id_user_memory == request.id_user_memory, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User_Memory), request.id_user_memory);
            }

            entity.content_memory = request.content_memory;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
