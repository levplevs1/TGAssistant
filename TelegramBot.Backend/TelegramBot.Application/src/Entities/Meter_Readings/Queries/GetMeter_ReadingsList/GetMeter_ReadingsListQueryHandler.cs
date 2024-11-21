using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Queries.GetMeter_ReadingsList
{
    public class GetMeter_ReadingsListQueryHandler
        : IRequestHandler<GetMeter_ReadingsListQuery, Meter_ReadingsListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMeter_ReadingsListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Meter_ReadingsListVm> Handle(GetMeter_ReadingsListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Meter_Readings
                .ProjectTo<Meter_ReadingsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new Meter_ReadingsListVm { Meter_Readings = entityQuery };
        }
    }
}
