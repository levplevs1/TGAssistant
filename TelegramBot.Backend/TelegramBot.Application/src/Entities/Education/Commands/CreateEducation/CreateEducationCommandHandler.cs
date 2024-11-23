using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Education.Commands.CreateEducation
{
    public class CreateEducationCommandHandler
        : IRequestHandler<CreateEducationCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateEducationCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            var education = new Domain.src.Entities.Education
            {
                text_of_request = request.text_of_request,
                created_at = DateTime.Now
            };

            await _dbContext.Education.AddAsync(education, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return education.id_education;
        }
    }
}
