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

namespace TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Queries.GetUnit_Of_TariffsDetails
{
    public class GetUnit_Of_TariffsDetailsQueryHandler
        : IRequestHandler<GetUnit_Of_TariffsDetailsQuery, Unit_Of_TariffsDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUnit_Of_TariffsDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Unit_Of_TariffsDetailsVm> Handle(GetUnit_Of_TariffsDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Unit_Of_Tariffs
                .FirstOrDefaultAsync(note =>
                note.id_unit_of_tariffs == request.id_unit_of_tariffs, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Unit_Of_Tariffs), request.id_unit_of_tariffs);
            }

            return _mapper.Map<Unit_Of_TariffsDetailsVm>(entity);
        }
    }
}
