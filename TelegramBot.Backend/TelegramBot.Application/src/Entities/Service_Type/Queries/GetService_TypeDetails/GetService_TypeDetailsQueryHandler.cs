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

namespace TelegramBot.Application.src.Entities.Service_Type.Queries.GetService_TypeDetails
{
    public class GetService_TypeDetailsQueryHandler
        : IRequestHandler<GetService_TypeDetailsQuery, Service_TypeDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetService_TypeDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Service_TypeDetailsVm> Handle(GetService_TypeDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Service_Type
                .FirstOrDefaultAsync(note =>
                note.id_service_type == request.id_service_type, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Service_Type), request.id_service_type);
            }

            return _mapper.Map<Service_TypeDetailsVm>(entity);
        }
    }
}
