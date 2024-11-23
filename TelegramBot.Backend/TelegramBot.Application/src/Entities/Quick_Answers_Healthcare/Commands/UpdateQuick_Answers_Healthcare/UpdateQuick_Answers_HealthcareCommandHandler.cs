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

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.UpdateQuick_Answers_Healthcare
{
    public class UpdateQuick_Answers_HealthcareCommandHandler
        : IRequestHandler<UpdateQuick_Answers_HealthcareCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateQuick_Answers_HealthcareCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateQuick_Answers_HealthcareCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Quick_Answers_Healthcare.FirstOrDefaultAsync(note =>
                note.id_quick_answer_healthcare == request.id_quick_answer_healthcare, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Quick_Answers_Healthcare), request.id_quick_answer_healthcare);
            }

            entity.quick_answer_healthcare_name = request.quick_answer_healthcare_name;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
