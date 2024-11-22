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

namespace TelegramBot.Application.src.Entities.Education.Queries.GetEducationDetails
{
    public class GetEducationDetailsQueryHandler
        : IRequestHandler<GetEducationDetailsQuery, EducationDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEducationDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EducationDetailsVm> Handle(GetEducationDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Education
                .FirstOrDefaultAsync(note =>
                note.id_education == request.id_education, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Education), request.id_education);
            }

            return _mapper.Map<EducationDetailsVm>(entity);
        }
    }
}
