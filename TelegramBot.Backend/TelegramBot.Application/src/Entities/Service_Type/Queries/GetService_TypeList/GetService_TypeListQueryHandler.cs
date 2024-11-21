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

namespace TelegramBot.Application.src.Entities.Service_Type.Queries.GetService_TypeList
{
    public class GetService_TypeListQueryHandler
        : IRequestHandler<GetService_TypeListQuery, Service_TypeListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetService_TypeListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Service_TypeListVm> Handle(GetService_TypeListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Service_Type
                .ProjectTo<Service_TypeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new Service_TypeListVm { Service_Type = entityQuery };
        }
    }
}
