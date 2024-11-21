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

namespace TelegramBot.Application.src.Entities.Healthcare.Queries.GetHealthcareList
{
    public class GetHealthcareListQueryHandler
        : IRequestHandler<GetHealthcareListQuery, HealthcareListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetHealthcareListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<HealthcareListVm> Handle(GetHealthcareListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Healthcare
                .ProjectTo<HealthcareLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new HealthcareListVm { Healthcare = entityQuery };
        }
    }
}
