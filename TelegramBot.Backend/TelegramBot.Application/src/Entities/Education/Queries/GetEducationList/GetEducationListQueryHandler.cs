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

namespace TelegramBot.Application.src.Entities.Education.Queries.GetEducationList
{
    public class GetEducationListQueryHandler
        : IRequestHandler<GetEducationListQuery, EducationListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEducationListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EducationListVm> Handle(GetEducationListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Education
                .ProjectTo<EducationLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EducationListVm { Education = entityQuery };
        }
    }
}
