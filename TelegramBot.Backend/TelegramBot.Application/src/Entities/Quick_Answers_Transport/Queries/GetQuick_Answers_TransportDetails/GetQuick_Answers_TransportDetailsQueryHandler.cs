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

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Queries.GetQuick_Answers_TransportDetails
{
    public class GetQuick_Answers_TransportDetailsQueryHandler
        : IRequestHandler<GetQuick_Answers_TransportDetailsQuery, Quick_Answers_TransportDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetQuick_Answers_TransportDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Quick_Answers_TransportDetailsVm> Handle(GetQuick_Answers_TransportDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Quick_Answers_Transport
                .FirstOrDefaultAsync(note =>
                note.id_quick_answer_transport == request.id_quick_answer_transport, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Quick_Answers_Transport), request.id_quick_answer_transport);
            }

            return _mapper.Map<Quick_Answers_TransportDetailsVm>(entity);
        }
    }
}
