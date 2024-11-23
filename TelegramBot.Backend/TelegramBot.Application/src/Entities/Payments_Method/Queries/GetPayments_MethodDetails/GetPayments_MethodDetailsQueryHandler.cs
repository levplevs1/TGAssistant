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

namespace TelegramBot.Application.src.Entities.Payments_Method.Queries.GetPayments_MethodDetails
{
    public class GetPayments_MethodDetailsQueryHandler
        : IRequestHandler<GetPayments_MethodDetailsQuery, Payments_MethodDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPayments_MethodDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Payments_MethodDetailsVm> Handle(GetPayments_MethodDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Payments_Method
                .FirstOrDefaultAsync(note =>
                note.id_payments_method == request.id_payments_method, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Payments_Method), request.id_payments_method);
            }

            return _mapper.Map<Payments_MethodDetailsVm>(entity);
        }
    }
}
