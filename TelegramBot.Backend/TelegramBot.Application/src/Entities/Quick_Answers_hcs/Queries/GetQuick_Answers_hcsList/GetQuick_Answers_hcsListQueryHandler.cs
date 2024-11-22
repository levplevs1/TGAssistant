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

namespace TelegramBot.Application.src.Entities.Quick_Answers_hcs.Queries.GetQuick_Answers_hcsList
{
    public class GetQuick_Answers_hcsListQueryHandler
        : IRequestHandler<GetQuick_Answers_hcsListQuery, Quick_Answers_hcsListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetQuick_Answers_hcsListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Quick_Answers_hcsListVm> Handle(GetQuick_Answers_hcsListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Quick_Answers_hcs
                .ProjectTo<Quick_Answers_hcsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new Quick_Answers_hcsListVm { Quick_Answers_hcs = entityQuery };
        }
    }
}
