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

namespace TelegramBot.Application.src.Entities.Meter_Readings.Commands.UpdateMeter_Readings
{
    public class UpdateMeter_ReadingsCommandHandler
        : IRequestHandler<UpdateMeter_ReadingsCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateMeter_ReadingsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateMeter_ReadingsCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Meter_Readings.FirstOrDefaultAsync(note =>
                note.id_meter_readings == request.id_meter_readings, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Meter_Readings), request.id_meter_readings);
            }

            entity.readings_value = request.readings_value;
            entity.previos_readings_value = request.previos_readings_value;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
