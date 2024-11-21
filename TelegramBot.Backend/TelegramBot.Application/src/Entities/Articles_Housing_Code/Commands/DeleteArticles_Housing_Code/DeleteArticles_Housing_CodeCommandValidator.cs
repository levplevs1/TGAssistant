using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.DeleteArticles_Housing_Code
{
    public class DeleteArticles_Housing_CodeCommandValidator : AbstractValidator<DeleteArticles_Housing_CodeCommand>
    {
        public DeleteArticles_Housing_CodeCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_articles_housing_code).NotEmpty();
        }
    }
}
