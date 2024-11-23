using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.User_Memory.Commands.CreateUser_Memory
{
    public class CreateUser_MemoryCommandHandler
        : IRequestHandler<CreateUser_MemoryCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateUser_MemoryCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateUser_MemoryCommand request, CancellationToken cancellationToken)
        {
            var user_memory = new Domain.src.Entities.User_Memory
            {
                content_memory = request.content_memory,
                id_users = request.id_users
            };

            await _dbContext.User_Memory.AddAsync(user_memory, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user_memory.id_user_memory;
        }
    }
}
