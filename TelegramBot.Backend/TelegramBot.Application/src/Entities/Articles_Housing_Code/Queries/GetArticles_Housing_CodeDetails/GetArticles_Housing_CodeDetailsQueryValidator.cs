using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Articles_Housing_Code.Queries.GetArticles_Housing_CodeDetails
{
    public class GetArticles_Housing_CodeDetailsQueryValidator : AbstractValidator<GetArticles_Housing_CodeDetailsQuery>
    {
        public GetArticles_Housing_CodeDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_articles_housing_code).NotEmpty();
        }
    }
}
