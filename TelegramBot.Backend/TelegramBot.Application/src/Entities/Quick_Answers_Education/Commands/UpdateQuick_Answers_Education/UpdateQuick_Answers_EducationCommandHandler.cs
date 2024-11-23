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

namespace TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.UpdateQuick_Answers_Education
{
    public class UpdateQuick_Answers_EducationCommandHandler
        : IRequestHandler<UpdateQuick_Answers_EducationCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateQuick_Answers_EducationCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateQuick_Answers_EducationCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Quick_Answers_Education.FirstOrDefaultAsync(note =>
                note.id_quick_answer_education == request.id_quick_answer_education, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Quick_Answers_Education), request.id_quick_answer_education);
            }

            entity.quick_answer_education_name = request.quick_answer_education_name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
