using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.DeleteArticles_Housing_Code
{
    public class DeleteArticles_Housing_CodeCommandHandler
        : IRequestHandler<DeleteArticles_Housing_CodeCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteArticles_Housing_CodeCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteArticles_Housing_CodeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Articles_Housing_Code
                .FindAsync(new object[] { request.id_articles_housing_code }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Articles_Housing_Code), request.id_articles_housing_code);
            }

            _dbContext.Articles_Housing_Code.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
