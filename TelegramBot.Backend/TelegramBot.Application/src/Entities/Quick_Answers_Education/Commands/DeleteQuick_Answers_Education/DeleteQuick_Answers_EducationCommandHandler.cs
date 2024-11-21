using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.DeleteQuick_Answers_Education
{
    public class DeleteQuick_Answers_EducationCommandHandler
        : IRequestHandler<DeleteQuick_Answers_EducationCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteQuick_Answers_EducationCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteQuick_Answers_EducationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Quick_Answers_Education
                .FindAsync(new object[] { request.id_quick_answer_education }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Quick_Answers_Education), request.id_quick_answer_education);
            }

            _dbContext.Quick_Answers_Education.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
