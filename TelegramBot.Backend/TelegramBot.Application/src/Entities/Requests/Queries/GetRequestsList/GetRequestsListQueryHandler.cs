using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Requests.Queries.GetRequestsList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Requests.Queries.GetRequestList
{
    public class GetRequestsListQueryHandler
        : IRequestHandler<GetRequestsListQuery, RequestsListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRequestsListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<RequestsListVm> Handle(GetRequestsListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Requests
                .ProjectTo<RequestsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new RequestsListVm { Requests = entityQuery };
        }
    }
}
