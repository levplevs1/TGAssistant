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

namespace TelegramBot.Application.src.Entities.Meter_Type.Commands.UpdateMeter_Type
{
    public class UpdateMeter_TypeCommandHandler
        : IRequestHandler<UpdateMeter_TypeCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateMeter_TypeCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateMeter_TypeCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Meter_Type.FirstOrDefaultAsync(note =>
                note.id_meter_type == request.id_meter_type, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Meter_Type), request.id_meter_type);
            }

            entity.meter_type_name = request.meter_type_name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
