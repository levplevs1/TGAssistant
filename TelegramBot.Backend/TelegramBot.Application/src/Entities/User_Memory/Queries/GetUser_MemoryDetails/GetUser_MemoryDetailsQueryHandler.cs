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

namespace TelegramBot.Application.src.Entities.User_Memory.Queries.GetUser_MemoryDetails
{
    public class GetUser_MemoryDetailsQueryHandler
        : IRequestHandler<GetUser_MemoryDetailsQuery, User_MemoryDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUser_MemoryDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<User_MemoryDetailsVm> Handle(GetUser_MemoryDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.User_Memory
                .FirstOrDefaultAsync(note =>
                note.id_user_memory == request.id_user_memory, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.User_Memory), request.id_user_memory);
            }

            return _mapper.Map<User_MemoryDetailsVm>(entity);
        }
    }
}
