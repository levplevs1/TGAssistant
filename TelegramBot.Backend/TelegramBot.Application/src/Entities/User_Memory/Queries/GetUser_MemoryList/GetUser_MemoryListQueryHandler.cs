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

namespace TelegramBot.Application.src.Entities.User_Memory.Queries.GetUser_MemoryList
{
    public class GetUser_MemoryListQueryHandler
        : IRequestHandler<GetUser_MemoryListQuery, User_MemoryListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUser_MemoryListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<User_MemoryListVm> Handle(GetUser_MemoryListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.User_Memory
                .ProjectTo<User_MemoryLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new User_MemoryListVm { User_Memory = entityQuery };
        }
    }
}
