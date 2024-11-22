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

namespace TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.UpdateUnit_Of_Tariffs
{
    public class UpdateUnit_Of_TariffsCommandHandler
        : IRequestHandler<UpdateUnit_Of_TariffsCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateUnit_Of_TariffsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateUnit_Of_TariffsCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Unit_Of_Tariffs.FirstOrDefaultAsync(note =>
                note.id_unit_of_tariffs == request.id_unit_of_tariffs, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Unit_Of_Tariffs), request.id_unit_of_tariffs);
            }

            entity.unit_of_tariffs_name = request.unit_of_tariffs_name;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
