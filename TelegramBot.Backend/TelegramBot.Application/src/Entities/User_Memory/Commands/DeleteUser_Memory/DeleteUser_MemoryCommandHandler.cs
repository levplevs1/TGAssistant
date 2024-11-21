using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.User_Memory.Commands.DeleteUser_Memory
{
    public class DeleteUser_MemoryCommandHandler
        : IRequestHandler<DeleteUser_MemoryCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteUser_MemoryCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteUser_MemoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.User_Memory
                .FindAsync(new object[] { request.id_user_memory }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User_Memory), request.id_user_memory);
            }

            _dbContext.User_Memory.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
