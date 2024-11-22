using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Tariffs.Commands.CreateTariffs
{
    public class CreateTariffsCommandHandler
        : IRequestHandler<CreateTariffsCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateTariffsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateTariffsCommand request, CancellationToken cancellationToken)
        {
            var tariffs = new Domain.src.Entities.Tariffs
            {
                id_housing_and_communal_services = request.id_housing_and_communal_services,
                id_unit_of_tariffs = request.id_unit_of_tariffs,
                id_service_type = request.id_service_type,
                tariff_value = request.tariff_value,
                effective_date = DateTime.Now
            };

            await _dbContext.Tariffs.AddAsync(tariffs, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return tariffs.id_tariffs;
        }
    }
}
