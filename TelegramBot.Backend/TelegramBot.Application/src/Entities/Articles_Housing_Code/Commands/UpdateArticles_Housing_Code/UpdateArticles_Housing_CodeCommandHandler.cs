using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.UpdateArticles_Housing_Code
{
    public class UpdateArticles_Housing_CodeCommandHandler
        : IRequestHandler<UpdateArticles_Housing_CodeCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateArticles_Housing_CodeCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateArticles_Housing_CodeCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Articles_Housing_Code.FirstOrDefaultAsync(note =>
                note.id_articles_housing_code == request.id_articles_housing_code, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Articles_Housing_Code), request.id_articles_housing_code);
            }

            entity.articles_housing_code_name = request.articles_housing_code_name;
            entity.articles_housing_code_content= request.articles_housing_code_content;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
