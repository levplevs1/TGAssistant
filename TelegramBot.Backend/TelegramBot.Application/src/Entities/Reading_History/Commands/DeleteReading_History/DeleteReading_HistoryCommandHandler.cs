using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Reading_History.Commands.DeleteReading_History
{
    public class DeleteReading_HistoryCommandHandler
        : IRequestHandler<DeleteReading_HistoryCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteReading_HistoryCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteReading_HistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Reading_History
                .FindAsync(new object[] { request.id_reading_history }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Reading_History), request.id_reading_history);
            }

            _dbContext.Reading_History.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
