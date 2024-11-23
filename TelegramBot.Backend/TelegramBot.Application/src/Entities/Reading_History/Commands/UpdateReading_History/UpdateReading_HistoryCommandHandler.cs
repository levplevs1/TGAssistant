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

namespace TelegramBot.Application.src.Entities.Reading_History.Commands.UpdateReading_History
{
    public class UpdateReading_HistoryCommandHandler
        : IRequestHandler<UpdateReading_HistoryCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateReading_HistoryCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateReading_HistoryCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Reading_History.FirstOrDefaultAsync(note =>
                note.id_reading_history == request.id_reading_history, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Reading_History), request.id_reading_history);
            }

            entity.reading_value = request.reading_value;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
