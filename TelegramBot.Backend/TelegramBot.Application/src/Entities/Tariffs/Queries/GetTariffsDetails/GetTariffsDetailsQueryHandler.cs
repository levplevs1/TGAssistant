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

namespace TelegramBot.Application.src.Entities.Tariffs.Queries.GetTariffsDetails
{
    public class GetTariffsDetailsQueryHandler
        : IRequestHandler<GetTariffsDetailsQuery, TariffsDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTariffsDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TariffsDetailsVm> Handle(GetTariffsDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tariffs
                .FirstOrDefaultAsync(note =>
                note.id_tariffs == request.id_tariffs, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Tariffs), request.id_tariffs);
            }

            return _mapper.Map<TariffsDetailsVm>(entity);
        }
    }
}
