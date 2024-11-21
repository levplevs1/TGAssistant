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

namespace TelegramBot.Application.src.Entities.Transport.Queries.GetTransportList
{
    public class GetTransportListQueryHandler
        : IRequestHandler<GetTransportListQuery, TransportListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTransportListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TransportListVm> Handle(GetTransportListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Transport
                .ProjectTo<TransportLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TransportListVm { Transport = entityQuery };
        }
    }
}
