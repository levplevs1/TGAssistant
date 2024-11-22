using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Requests.Commands.CreateRequest;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Requests.Commands.CreateRequests
{
    public class CreateRequestsCommandHandler
        : IRequestHandler<CreateRequestsCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateRequestsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateRequestsCommand request, CancellationToken cancellationToken)
        {
            var requests = new Domain.src.Entities.Requests
            {
                request_text = request.request_text,
                response = request.response,
                created_at = DateTime.Now,
                id_type_of_requests = request.id_type_of_requests,
                id_users = request.id_users
            };

            await _dbContext.Requests.AddAsync(requests, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return requests.id_requests;
        }
    }
}
