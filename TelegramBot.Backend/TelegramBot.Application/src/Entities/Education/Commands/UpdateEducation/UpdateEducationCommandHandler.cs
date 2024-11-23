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

namespace TelegramBot.Application.src.Entities.Education.Commands.UpdateEducation
{
    public class UpdateEducationCommandHandler
        : IRequestHandler<UpdateEducationCommand>   
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateEducationCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Education.FirstOrDefaultAsync(note =>
                note.id_education == request.id_education, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Education), request.id_education);
            }

            entity.text_of_request = request.text_of_request;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
