using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Meters.Commands.CreateMeters
{
    public class CreateMetersCommandHandler
        : IRequestHandler<CreateMetersCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateMetersCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateMetersCommand request, CancellationToken cancellationToken)
        {
            var meters = new Domain.src.Entities.Meters
            {
                instalition_date = DateTime.Now,
                last_reading_date = null,
                id_users = request.id_users,
                id_meter_type = request.id_meter_type
            };

            await _dbContext.Meters.AddAsync(meters, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return meters.id_meters;
        }
    }
}
