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

namespace TelegramBot.Application.src.Entities.Articles_Housing_Code.Queries.GetArticles_Housing_CodeDetails
{
    public class GetArticles_Housing_CodeDetailsQueryHandler
        : IRequestHandler<GetArticles_Housing_CodeDetailsQuery, Articles_Housing_CodeDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetArticles_Housing_CodeDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Articles_Housing_CodeDetailsVm> Handle(GetArticles_Housing_CodeDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Articles_Housing_Code
                .FirstOrDefaultAsync(note =>
                note.id_articles_housing_code == request.id_articles_housing_code, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Articles_Housing_Code), request.id_articles_housing_code);
            }

            return _mapper.Map<Articles_Housing_CodeDetailsVm>(entity);
        }
    }
}
