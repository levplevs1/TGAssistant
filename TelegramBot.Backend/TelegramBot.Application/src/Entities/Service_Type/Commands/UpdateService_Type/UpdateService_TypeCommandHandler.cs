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

namespace TelegramBot.Application.src.Entities.Service_Type.Commands.UpdateService_Type
{
    public class UpdateService_TypeCommandHandler
        : IRequestHandler<UpdateService_TypeCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateService_TypeCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateService_TypeCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Service_Type.FirstOrDefaultAsync(note =>
                note.id_service_type == request.id_service_type, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Service_Type), request.id_service_type);
            }

            entity.service_type_name = request.service_type_name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
