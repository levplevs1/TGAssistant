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

namespace TelegramBot.Application.src.Entities.Tariffs.Commands.UpdateTariffs
{
    public class UpdateTariffsCommandHandler
        : IRequestHandler<UpdateTariffsCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateTariffsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateTariffsCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Tariffs.FirstOrDefaultAsync(note =>
                note.id_tariffs == request.id_tariffs, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Tariffs), request.id_tariffs);
            }

            entity.tariff_value = request.tariff_value;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
