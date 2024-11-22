using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Healthcare.Commands.DeleteHealthcare
{
    public class DeleteHealthcareCommandHandler
        : IRequestHandler<DeleteHealthcareCommand>  
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteHealthcareCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteHealthcareCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Healthcare
                .FindAsync(new object[] { request.id_healthcare }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Healthcare), request.id_healthcare);
            }

            _dbContext.Healthcare.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
