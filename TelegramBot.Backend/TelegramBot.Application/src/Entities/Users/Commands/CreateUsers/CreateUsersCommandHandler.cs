using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Users.Commands.CreateUsers
{
    public class CreateUsersCommandHandler
        : IRequestHandler<CreateUsersCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateUsersCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateUsersCommand request, CancellationToken cancellationToken)
        {
            var users = new Domain.src.Entities.Users
            {
                id_telegram = request.id_telegram,
                name = request.name,
                lastname = request.lastname,
                username = request.username,
                created_at = DateTime.Now
            };

            await _dbContext.Users.AddAsync(users, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return users.id_users;
        }
    }
}
