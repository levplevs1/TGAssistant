using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Requests.Queries.GetRequestsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Requests.Queries.GetRequestsDetails
{
    public class GetRequestsDetailsQueryHandler
        : IRequestHandler<GetRequestsDetailsQuery, RequestsDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRequestsDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<RequestsDetailsVm> Handle(GetRequestsDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Requests
                .FirstOrDefaultAsync(note =>
                note.id_requests == request.id_requests, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Requests), request.id_requests);
            }

            return _mapper.Map<RequestsDetailsVm>(entity);
        }
    }
}
