using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Service_Type.Commands.DeleteService_Type
{
    public class DeleteService_TypeCommandHandler
        : IRequestHandler<DeleteService_TypeCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteService_TypeCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteService_TypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Service_Type
                .FindAsync(new object[] { request.id_service_type }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Service_Type), request.id_service_type);
            }

            _dbContext.Service_Type.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
