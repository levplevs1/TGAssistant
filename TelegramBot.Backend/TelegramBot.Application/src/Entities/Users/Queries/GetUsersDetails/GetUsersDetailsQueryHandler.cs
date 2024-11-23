using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails
{
    public class GetUsersDetailsQueryHandler
        : IRequestHandler<GetUsersDetailsQuery, UsersDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUsersDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UsersDetailsVm> Handle(GetUsersDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users
                .FirstOrDefaultAsync(note =>
                note.id_users == request.id_users, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Users), request.id_users);
            }

            return _mapper.Map<UsersDetailsVm>(entity);
        }
    }
}
