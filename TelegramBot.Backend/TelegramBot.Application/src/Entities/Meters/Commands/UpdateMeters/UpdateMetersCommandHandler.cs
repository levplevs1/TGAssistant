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

namespace TelegramBot.Application.src.Entities.Meters.Commands.UpdateMeters
{
    public class UpdateMetersCommandHandler
        : IRequestHandler<UpdateMetersCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateMetersCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateMetersCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Meters.FirstOrDefaultAsync(note =>
                note.id_meters == request.id_meters, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Meters), request.id_meters);
            }

            entity.last_reading_date = DateTime.Now;
            entity.id_meter_type = request.id_meter_type;
            entity.id_users = request.id_users;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
