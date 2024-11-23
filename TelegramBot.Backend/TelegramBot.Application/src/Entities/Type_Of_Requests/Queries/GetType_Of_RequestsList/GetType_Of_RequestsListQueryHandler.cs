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

namespace TelegramBot.Application.src.Entities.Type_Of_Requests.Queries.GetType_Of_RequestsList
{
    public class GetType_Of_RequestsListQueryHandler
        : IRequestHandler<GetType_Of_RequestsListQuery, Type_Of_RequestsListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetType_Of_RequestsListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Type_Of_RequestsListVm> Handle(GetType_Of_RequestsListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Type_Of_Requests
                .ProjectTo<Type_Of_RequestsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new Type_Of_RequestsListVm { Type_Of_Requests = entityQuery };
        }
    }
}
