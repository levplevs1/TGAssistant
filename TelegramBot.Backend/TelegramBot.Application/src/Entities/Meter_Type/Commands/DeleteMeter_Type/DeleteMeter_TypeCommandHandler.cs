using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Meter_Type.Commands.DeleteMeter_Type
{
    public class DeleteMeter_TypeCommandHandler
        : IRequestHandler<DeleteMeter_TypeCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteMeter_TypeCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteMeter_TypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meter_Type
                .FindAsync(new object[] { request.id_meter_type }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Meter_Type), request.id_meter_type);
            }

            _dbContext.Meter_Type.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
