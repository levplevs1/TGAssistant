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

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Queries.GetQuick_Answers_TransportList
{
    public class GetQuick_Answers_TransportListQueryHandler
        : IRequestHandler<GetQuick_Answers_TransportListQuery, Quick_Answers_TransportListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetQuick_Answers_TransportListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Quick_Answers_TransportListVm> Handle(GetQuick_Answers_TransportListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Quick_Answers_Transport
                .ProjectTo<Quick_Answers_TransportLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new Quick_Answers_TransportListVm { Quick_Answers_Transport = entityQuery };
        }
    }
}
