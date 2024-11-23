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

namespace TelegramBot.Application.src.Entities.Meters.Queries.GetMetersList
{
    public class GetMetersListQueryHandler
        : IRequestHandler<GetMetersListQuery, MetersListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMetersListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<MetersListVm> Handle(GetMetersListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Meters
                .ProjectTo<MetersLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MetersListVm { Meters = entityQuery };
        }
    }
}
