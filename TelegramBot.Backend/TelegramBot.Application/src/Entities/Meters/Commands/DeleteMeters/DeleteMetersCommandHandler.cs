using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Meters.Commands.DeleteMeters
{
    public class DeleteMetersCommandHandler
        : IRequest<DeleteMetersCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteMetersCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteMetersCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meters
                .FindAsync(new object[] { request.id_meters }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Meters), request.id_meters);
            }

            _dbContext.Meters.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
