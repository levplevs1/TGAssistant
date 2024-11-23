using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.DeleteUnit_Of_Tariffs
{
    public class DeleteUnit_Of_TariffsCommandHandler
        : IRequestHandler<DeleteUnit_Of_TariffsCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteUnit_Of_TariffsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteUnit_Of_TariffsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Unit_Of_Tariffs
                .FindAsync(new object[] { request.id_unit_of_tariffs }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Unit_Of_Tariffs), request.id_unit_of_tariffs);
            }

            _dbContext.Unit_Of_Tariffs.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
