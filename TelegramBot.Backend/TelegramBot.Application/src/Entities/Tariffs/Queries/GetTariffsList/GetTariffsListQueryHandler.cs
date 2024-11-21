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

namespace TelegramBot.Application.src.Entities.Tariffs.Queries.GetTariffsList
{
    public class GetTariffsListQueryHandler
        : IRequestHandler<GetTariffsListQuery, TariffsListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTariffsListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TariffsListVm> Handle(GetTariffsListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Tariffs
                .ProjectTo<TariffsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TariffsListVm { Tariffs = entityQuery };
        }
    }
}
