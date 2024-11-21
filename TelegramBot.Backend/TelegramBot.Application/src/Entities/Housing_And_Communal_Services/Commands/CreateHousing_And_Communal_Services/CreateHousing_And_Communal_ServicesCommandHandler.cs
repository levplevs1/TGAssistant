using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Commands.CreateHousing_And_Communal_Services
{
    public class CreateHousing_And_Communal_ServicesCommandHandler
        : IRequestHandler<CreateHousing_And_Communal_ServicesCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateHousing_And_Communal_ServicesCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateHousing_And_Communal_ServicesCommand request, CancellationToken cancellationToken)
        {
            var housing_and_communal_services = new Domain.src.Entities.Housing_And_Communal_Services
            {
                text_of_request = request.text_of_request,
                created_at = DateTime.Now
            };

            await _dbContext.Housing_And_Communal_Services.AddAsync(housing_and_communal_services, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return housing_and_communal_services.id_housing_and_communal_services;
        }
    }
}
