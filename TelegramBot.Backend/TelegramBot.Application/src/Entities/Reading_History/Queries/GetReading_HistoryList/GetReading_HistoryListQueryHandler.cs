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

namespace TelegramBot.Application.src.Entities.Reading_History.Queries.GetReading_HistoryList
{
    public class GetReading_HistoryListQueryHandler
        : IRequestHandler<GetReading_HistoryListQuery, Reading_HistoryListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReading_HistoryListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Reading_HistoryListVm> Handle(GetReading_HistoryListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Reading_History
                .ProjectTo<Reading_HistoryLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new Reading_HistoryListVm { Reading_History = entityQuery };
        }
    }
}
