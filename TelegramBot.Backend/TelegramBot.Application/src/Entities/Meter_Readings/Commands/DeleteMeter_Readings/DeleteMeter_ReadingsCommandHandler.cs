using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Commands.DeleteMeter_Readings
{
    public class DeleteMeter_ReadingsCommandHandler
        : IRequestHandler<DeleteMeter_ReadingsCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteMeter_ReadingsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteMeter_ReadingsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meter_Readings
                .FindAsync(new object[] { request.id_meter_readings }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Meter_Readings), request.id_meter_readings);
            }

            _dbContext.Meter_Readings.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
