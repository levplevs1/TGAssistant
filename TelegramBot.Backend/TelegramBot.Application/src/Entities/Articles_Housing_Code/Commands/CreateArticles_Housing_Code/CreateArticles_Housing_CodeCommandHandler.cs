using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.CreateArticles_Housing_Code
{
    public class CreateArticles_Housing_CodeCommandHandler
        : IRequestHandler<CreateArticles_Housing_CodeCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateArticles_Housing_CodeCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateArticles_Housing_CodeCommand request, CancellationToken cancellationToken)
        {
            var articles_housing_code = new Domain.src.Entities.Articles_Housing_Code
            {
                articles_housing_code_name = request.articles_housing_code_name,
                articles_housing_code_content = request.articles_housing_code_content,
                id_housing_and_communal_services = request.id_housing_and_communal_services
            };

            await _dbContext.Articles_Housing_Code.AddAsync(articles_housing_code, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return articles_housing_code.id_articles_housing_code;
        }
    }
}
