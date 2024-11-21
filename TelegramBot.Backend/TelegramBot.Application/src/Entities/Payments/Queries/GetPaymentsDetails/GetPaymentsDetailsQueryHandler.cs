using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Payments.Queries.GetPaymentsDetails
{
    public class GetPaymentsDetailsQueryHandler
        : IRequestHandler<GetPaymentsDetailsQuery, PaymentsDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPaymentsDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PaymentsDetailsVm> Handle(GetPaymentsDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Payments
                .FirstOrDefaultAsync(note =>
                note.id_payments == request.id_payments, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Payments), request.id_payments);
            }

            return _mapper.Map<PaymentsDetailsVm>(entity);
        }
    }
}
