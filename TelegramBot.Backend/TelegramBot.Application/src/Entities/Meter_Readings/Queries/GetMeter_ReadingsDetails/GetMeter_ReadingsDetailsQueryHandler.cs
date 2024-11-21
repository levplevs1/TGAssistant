using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Queries.GetMeter_ReadingsDetails
{
    public class GetMeter_ReadingsDetailsQueryHandler
        : IRequestHandler<GetMeter_ReadingsDetailsQuery, Meter_ReadingsDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMeter_ReadingsDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Meter_ReadingsDetailsVm> Handle(GetMeter_ReadingsDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meter_Readings
                .FirstOrDefaultAsync(note =>
                note.id_meter_readings == request.id_meter_readings, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Meter_Readings), request.id_meter_readings);
            }

            return _mapper.Map<Meter_ReadingsDetailsVm>(entity);
        }
    }
}
