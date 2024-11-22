using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.UpdateArticles_Housing_Code
{
    public class UpdateArticles_Housing_CodeCommandValidator : AbstractValidator<UpdateArticles_Housing_CodeCommand>
    {
        public UpdateArticles_Housing_CodeCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.articles_housing_code_name).MaximumLength(250);
            RuleFor(updateEntityCommand =>
            updateEntityCommand.articles_housing_code_content).MaximumLength(250);
        }
    }
}
