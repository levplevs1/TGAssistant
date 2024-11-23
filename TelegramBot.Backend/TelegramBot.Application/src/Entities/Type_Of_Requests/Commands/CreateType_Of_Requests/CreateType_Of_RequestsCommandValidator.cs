using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Type_Of_Requests.Commands.CreateType_Of_Requests
{
    public class CreateType_Of_RequestsCommandValidator : AbstractValidator<CreateType_Of_RequestsCommand>
    {
        public CreateType_Of_RequestsCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.id_housing_and_communal_services);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_healthcare);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_transport);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_education);
        }
    }
}
