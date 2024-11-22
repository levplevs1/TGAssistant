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

namespace TelegramBot.Application.src.Entities.Meter_Type.Queries.GetMeter_TypeList
{
    public class GetMeter_TypeListQueryHandler
        : IRequestHandler<GetMeter_TypeListQuery, Meter_TypeListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMeter_TypeListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Meter_TypeListVm> Handle(GetMeter_TypeListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Meter_Type
                .ProjectTo<Meter_TypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new Meter_TypeListVm { Meter_Type = entityQuery };
        }
    }
}
