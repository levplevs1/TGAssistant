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

namespace TelegramBot.Application.src.Entities.Reading_History.Queries.GetReading_HistoryDetails
{
    public class GetReading_HistoryDetailsQueryHandler
        : IRequestHandler<GetReading_HistoryDetailsQuery, Reading_HistoryDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReading_HistoryDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Reading_HistoryDetailsVm> Handle(GetReading_HistoryDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Reading_History
                .FirstOrDefaultAsync(note =>
                note.id_reading_history == request.id_reading_history, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Reading_History), request.id_reading_history);
            }

            return _mapper.Map<Reading_HistoryDetailsVm>(entity);
        }
    }
}
