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

namespace TelegramBot.Application.src.Entities.Type_Of_Requests.Queries.GetType_Of_RequestsDetails
{
    public class GetType_Of_RequestsDetailsQueryHandler
        : IRequestHandler<GetType_Of_RequestsDetailsQuery, Type_Of_RequestsDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetType_Of_RequestsDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Type_Of_RequestsDetailsVm> Handle(GetType_Of_RequestsDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Type_Of_Requests
                .FirstOrDefaultAsync(note =>
                note.id_type_of_requests == request.id_type_of_requests, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Type_Of_Requests), request.id_type_of_requests);
            }

            return _mapper.Map<Type_Of_RequestsDetailsVm>(entity);
        }
    }
}
