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

namespace TelegramBot.Application.src.Entities.Healthcare.Commands.UpdateHealthcare
{
    public class UpdateHealthcareCommandHandler
        : IRequestHandler<UpdateHealthcareCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateHealthcareCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateHealthcareCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Healthcare.FirstOrDefaultAsync(note =>
                note.id_healthcare == request.id_healthcare, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Healthcare), request.id_healthcare);
            }

            entity.text_of_request = request.text_of_request;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
