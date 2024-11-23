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

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Queries.GetQuick_Answers_HealthcareDetails
{
    public class GetQuick_Answers_HealthcareDetailsQueryHandler
        : IRequestHandler<GetQuick_Answers_HealthcareDetailsQuery, Quick_Answers_HealthcareDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetQuick_Answers_HealthcareDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Quick_Answers_HealthcareDetailsVm> Handle(GetQuick_Answers_HealthcareDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Quick_Answers_Healthcare
                .FirstOrDefaultAsync(note =>
                note.id_quick_answer_healthcare == request.id_quick_answer_healthcare, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Quick_Answers_Healthcare), request.id_quick_answer_healthcare);
            }

            return _mapper.Map<Quick_Answers_HealthcareDetailsVm>(entity);
        }
    }
}
