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

namespace TelegramBot.Application.src.Entities.Quick_Answers_Education.Queries.GetQuick_Answers_EducationList
{
    public class GetQuick_Answers_EducationListQueryHandler
        : IRequestHandler<GetQuick_Answers_EducationListQuery, Quick_Answers_EducationListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetQuick_Answers_EducationListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Quick_Answers_EducationListVm> Handle(GetQuick_Answers_EducationListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Quick_Answers_Education
                .ProjectTo<Quick_Answers_EducationLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new Quick_Answers_EducationListVm { Quick_Answers_Education = entityQuery };
        }
    }
}
