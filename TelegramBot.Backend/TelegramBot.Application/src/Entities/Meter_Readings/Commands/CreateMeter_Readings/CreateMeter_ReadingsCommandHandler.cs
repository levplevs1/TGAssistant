using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Commands.CreateMeter_Readings
{
    public class CreateMeter_ReadingsCommandHandler
        : IRequestHandler<CreateMeter_ReadingsCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateMeter_ReadingsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateMeter_ReadingsCommand request, CancellationToken cancellationToken)
        {
            var meter_readings = new Domain.src.Entities.Meter_Readings
            {
                readings_value = request.readings_value,
                previos_readings_value = request.previos_readings_value,
                id_meters = request.id_meters,
                id_housing_and_communal_services = request.id_housing_and_communal_services,
                readings_date = DateTime.Now
            };

            await _dbContext.Meter_Readings.AddAsync(meter_readings, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return meter_readings.id_meter_readings;
        }
    }
}
