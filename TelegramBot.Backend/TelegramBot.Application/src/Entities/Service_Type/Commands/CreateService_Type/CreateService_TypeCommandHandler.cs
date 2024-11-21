using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Service_Type.Commands.CreateService_Type
{
    public class CreateService_TypeCommandHandler
        : IRequestHandler<CreateService_TypeCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateService_TypeCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateService_TypeCommand request, CancellationToken cancellationToken)
        {
            var service_type = new Domain.src.Entities.Service_Type
            {
                id_housing_and_communal_services = request.id_housing_and_communal_services,
                service_type_name = request.service_type_name
            };

            await _dbContext.Service_Type.AddAsync(service_type, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return service_type.id_service_type;
        }
    }
}
