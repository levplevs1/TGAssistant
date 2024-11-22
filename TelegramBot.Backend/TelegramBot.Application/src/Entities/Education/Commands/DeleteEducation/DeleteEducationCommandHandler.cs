using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Education.Commands.DeleteEducation
{
    public class DeleteEducationCommandHandler
        : IRequestHandler<DeleteEducationCommand>   
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteEducationCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Education
                .FindAsync(new object[] { request.id_education }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Education), request.id_education);
            }

            _dbContext.Education.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
