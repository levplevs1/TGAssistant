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

namespace TelegramBot.Application.src.Entities.Articles_Housing_Code.Queries.GetArticles_Housing_CodeList
{
    public class GetArticles_Housing_CodeListQueryHandler
        : IRequestHandler<GetArticles_Housing_CodeListQuery, Articles_Housing_CodeListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetArticles_Housing_CodeListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Articles_Housing_CodeListVm> Handle(GetArticles_Housing_CodeListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Articles_Housing_Code
                .ProjectTo<Articles_Housing_CodeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new Articles_Housing_CodeListVm { Articles_Housing_Code = entityQuery };
        }
    }
}
