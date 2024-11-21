using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.DeleteQuick_Answers_hcs
{
    public class DeleteQuick_Answers_hcsCommandHandler
        : IRequestHandler<DeleteQuick_Answers_hcsCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteQuick_Answers_hcsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteQuick_Answers_hcsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Quick_Answers_hcs
                .FindAsync(new object[] { request.id_quick_answers_hcs }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Quick_Answers_hcs), request.id_quick_answers_hcs);
            }

            _dbContext.Quick_Answers_hcs.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
