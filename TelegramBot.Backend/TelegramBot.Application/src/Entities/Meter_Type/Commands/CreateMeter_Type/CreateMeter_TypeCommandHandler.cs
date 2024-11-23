using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Meter_Type.Commands.CreateMeter_Type
{
    public class CreateMeter_TypeCommandHandler
        : IRequestHandler<CreateMeter_TypeCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateMeter_TypeCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateMeter_TypeCommand request, CancellationToken cancellationToken)
        {
            var meter_type = new Domain.src.Entities.Meter_Type
            {
                meter_type_name = request.meter_type_name
            };

            await _dbContext.Meter_Type.AddAsync(meter_type, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return meter_type.id_meter_type;
        }
    }
}
