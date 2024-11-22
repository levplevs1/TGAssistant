using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Tariffs.Commands.DeleteTariffs
{
    public class DeleteTariffsCommandHandler
        : IRequestHandler<DeleteTariffsCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteTariffsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteTariffsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tariffs
                .FindAsync(new object[] { request.id_tariffs }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Tariffs), request.id_tariffs);
            }

            _dbContext.Tariffs.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
