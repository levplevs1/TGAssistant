using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.CreateQuick_Answers_Healthcare
{
    public class CreateQuick_Answers_HealthcareCommandHandler
        : IRequestHandler<CreateQuick_Answers_HealthcareCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateQuick_Answers_HealthcareCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateQuick_Answers_HealthcareCommand request, CancellationToken cancellationToken)
        {
            var quick_answers_healthcare = new Domain.src.Entities.Quick_Answers_Healthcare
            {
                id_healthcare = request.id_healthcare,
                quick_answer_healthcare_name = request.quick_answer_healthcare_name
            };

            await _dbContext.Quick_Answers_Healthcare.AddAsync(quick_answers_healthcare, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return quick_answers_healthcare.id_quick_answer_healthcare;
        }
    }
}
