using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler
        : IRequestHandler<GetUsersListQuery, UsersListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UsersListVm> Handle(GetUsersListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Users
                .ProjectTo<UsersLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UsersListVm { Users = entityQuery };
        }
    }
}
