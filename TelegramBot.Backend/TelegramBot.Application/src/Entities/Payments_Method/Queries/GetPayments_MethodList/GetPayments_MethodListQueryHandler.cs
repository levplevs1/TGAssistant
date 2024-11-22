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

namespace TelegramBot.Application.src.Entities.Payments_Method.Queries.GetPayments_MethodList
{
    public class GetPayments_MethodListQueryHandler
        : IRequestHandler<GetPayments_MethodListQuery, Payments_MethodListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPayments_MethodListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Payments_MethodListVm> Handle(GetPayments_MethodListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Payments_Method
                .ProjectTo<Payments_MethodLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new Payments_MethodListVm { Payments_Method = entityQuery };
        }
    }
}
