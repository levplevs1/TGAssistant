using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.CreateQuick_Answers_Education
{
    public class CreateQuick_Answers_EducationCommandHandler
        : IRequestHandler<CreateQuick_Answers_EducationCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateQuick_Answers_EducationCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateQuick_Answers_EducationCommand request, CancellationToken cancellationToken)
        {
            var quick_answers_education = new Domain.src.Entities.Quick_Answers_Education
            {
                id_education = request.id_education,
                quick_answer_education_name = request.quick_answer_education_name
            };

            await _dbContext.Quick_Answers_Education.AddAsync(quick_answers_education, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return quick_answers_education.id_quick_answer_education;
        }
    }
}
