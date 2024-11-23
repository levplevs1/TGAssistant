using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Reading_History.Commands.CreateReading_History
{
    public class CreateReading_HistoryCommandHandler
        : IRequestHandler<CreateReading_HistoryCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateReading_HistoryCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateReading_HistoryCommand request, CancellationToken cancellationToken)
        {
            var reading_history = new Domain.src.Entities.Reading_History
            {
                reading_value = request.reading_value,
                id_housing_and_communal_services = request.id_housing_and_communal_services,
                id_meters = request.id_meters,
                reading_date = DateTime.Now
            };

            await _dbContext.Reading_History.AddAsync(reading_history, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return reading_history.id_reading_history;
        }
    }
}
