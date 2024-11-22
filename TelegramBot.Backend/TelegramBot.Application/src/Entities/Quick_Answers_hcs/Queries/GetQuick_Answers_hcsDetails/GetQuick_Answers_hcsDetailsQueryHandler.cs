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

namespace TelegramBot.Application.src.Entities.Quick_Answers_hcs.Queries.GetQuick_Answers_hcsDetails
{
    public class GetQuick_Answers_hcsDetailsQueryHandler
        : IRequestHandler<GetQuick_Answers_hcsDetailsQuery, Quick_Answers_hcsDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetQuick_Answers_hcsDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Quick_Answers_hcsDetailsVm> Handle(GetQuick_Answers_hcsDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Quick_Answers_hcs
                .FirstOrDefaultAsync(note =>
                note.id_quick_answers_hcs == request.id_quick_answers_hcs, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Quick_Answers_hcs), request.id_quick_answers_hcs);
            }

            return _mapper.Map<Quick_Answers_hcsDetailsVm>(entity);
        }
    }
}
