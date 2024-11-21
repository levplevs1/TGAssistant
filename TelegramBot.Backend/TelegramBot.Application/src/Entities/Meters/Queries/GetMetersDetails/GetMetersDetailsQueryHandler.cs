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

namespace TelegramBot.Application.src.Entities.Meters.Queries.GetMetersDetails
{
    public class GetMetersDetailsQueryHandler
        : IRequestHandler<GetMetersDetailsQuery, MetersDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMetersDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<MetersDetailsVm> Handle(GetMetersDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meters
                .FirstOrDefaultAsync(note =>
                note.id_meters == request.id_meters, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Meters), request.id_meters);
            }

            return _mapper.Map<MetersDetailsVm>(entity);
        }
    }
}
