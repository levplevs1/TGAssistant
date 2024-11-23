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

namespace TelegramBot.Application.src.Entities.Healthcare.Queries.GetHealthcareDetails
{
    public class GetHealthcareDetailsQueryHandler
        : IRequestHandler<GetHealthcareDetailsQuery, HealthcareDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetHealthcareDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<HealthcareDetailsVm> Handle(GetHealthcareDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Healthcare
                .FirstOrDefaultAsync(note =>
                note.id_healthcare == request.id_healthcare, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Healthcare), request.id_healthcare);
            }

            return _mapper.Map<HealthcareDetailsVm>(entity);
        }
    }
}
