using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Queries.GetQuick_Answers_HealthcareList
{
    public class GetQuick_Answers_HealthcareListQueryHandler
        : IRequestHandler<GetQuick_Answers_HealthcareListQuery, Quick_Answers_HealthcareListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetQuick_Answers_HealthcareListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Quick_Answers_HealthcareListVm> Handle(GetQuick_Answers_HealthcareListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Quick_Answers_Healthcare
                .ProjectTo<Quick_Answers_HealthcareLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new Quick_Answers_HealthcareListVm { Quick_Answers_Healthcare = entityQuery };
        }
    }
}
