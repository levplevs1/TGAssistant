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

namespace TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Queries.GetUnit_Of_TariffsList
{
    public class GetUnit_Of_TariffsListQueryHandler
        : IRequestHandler<GetUnit_Of_TariffsListQuery, Unit_Of_TariffsListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUnit_Of_TariffsListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Unit_Of_TariffsListVm> Handle(GetUnit_Of_TariffsListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Unit_Of_Tariffs
                .ProjectTo<Unit_Of_TariffsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new Unit_Of_TariffsListVm { Unit_Of_Tariffs = entityQuery };
        }
    }
}
