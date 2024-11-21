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

namespace TelegramBot.Application.src.Entities.Transport.Queries.GetTransportDetails
{
    public class GetTransportDetailsQueryHandler
        : IRequestHandler<GetTransportDetailsQuery, TransportDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTransportDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TransportDetailsVm> Handle(GetTransportDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Transport
                .FirstOrDefaultAsync(note =>
                note.id_transport == request.id_transport, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Transport), request.id_transport);
            }

            return _mapper.Map<TransportDetailsVm>(entity);
        }
    }
}
