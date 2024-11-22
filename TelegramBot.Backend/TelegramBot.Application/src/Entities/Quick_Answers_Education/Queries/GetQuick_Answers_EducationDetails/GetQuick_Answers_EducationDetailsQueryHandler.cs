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

namespace TelegramBot.Application.src.Entities.Quick_Answers_Education.Queries.GetQuick_Answers_EducationDetails
{
    public class GetQuick_Answers_EducationDetailsQueryHandler
        : IRequestHandler<GetQuick_Answers_EducationDetailsQuery, Quick_Answers_EducationDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetQuick_Answers_EducationDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Quick_Answers_EducationDetailsVm> Handle(GetQuick_Answers_EducationDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Quick_Answers_Education
                .FirstOrDefaultAsync(note =>
                note.id_quick_answer_education == request.id_quick_answer_education, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Quick_Answers_Education), request.id_quick_answer_education);
            }

            return _mapper.Map<Quick_Answers_EducationDetailsVm>(entity);
        }
    }
}
