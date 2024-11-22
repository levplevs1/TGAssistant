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

namespace TelegramBot.Application.src.Entities.Payments.Queries.GetPaymentsList
{
    public class GetPaymentsListQueryHandler
        : IRequestHandler<GetPaymentsListQuery, PaymentsListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPaymentsListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PaymentsListVm> Handle(GetPaymentsListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Payments
                .ProjectTo<PaymentsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PaymentsListVm { Payments = entityQuery };
        }
    }
}
