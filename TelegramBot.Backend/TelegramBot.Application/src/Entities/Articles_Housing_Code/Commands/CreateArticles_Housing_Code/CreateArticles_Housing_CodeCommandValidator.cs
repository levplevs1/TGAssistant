using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.CreateArticles_Housing_Code
{
    public class CreateArticles_Housing_CodeCommandValidator : AbstractValidator<CreateArticles_Housing_CodeCommand>
    {
        public CreateArticles_Housing_CodeCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.articles_housing_code_name).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.articles_housing_code_content).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_housing_and_communal_services);
        }
    }
}
