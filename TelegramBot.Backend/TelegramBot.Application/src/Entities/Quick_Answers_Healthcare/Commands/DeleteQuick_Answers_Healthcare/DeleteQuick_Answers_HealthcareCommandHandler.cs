using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.DeleteQuick_Answers_Healthcare
{
    public class DeleteQuick_Answers_HealthcareCommandHandler
        : IRequestHandler<DeleteQuick_Answers_HealthcareCommand>    
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteQuick_Answers_HealthcareCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteQuick_Answers_HealthcareCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Quick_Answers_Healthcare
                .FindAsync(new object[] { request.id_quick_answer_healthcare }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Quick_Answers_Healthcare), request.id_quick_answer_healthcare);
            }

            _dbContext.Quick_Answers_Healthcare.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
