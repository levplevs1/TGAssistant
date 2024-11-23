using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Type_Of_Requests.Commands.CreateType_Of_Requests
{
    public class CreateType_Of_RequestsCommandHandler
        : IRequestHandler<CreateType_Of_RequestsCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateType_Of_RequestsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateType_Of_RequestsCommand request, CancellationToken cancellationToken)
        {
            var type_of_requests = new Domain.src.Entities.Type_Of_Requests
            {
                id_housing_and_communal_services = request.id_housing_and_communal_services,
                id_healthcare = request.id_healthcare,
                id_transport = request.id_transport,
                id_education = request.id_education
            };

            await _dbContext.Type_Of_Requests.AddAsync(type_of_requests, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return type_of_requests.id_type_of_requests;
        }
    }
}
