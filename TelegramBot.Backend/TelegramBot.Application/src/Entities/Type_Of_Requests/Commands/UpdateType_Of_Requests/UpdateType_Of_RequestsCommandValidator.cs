using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Type_Of_Requests.Commands.UpdateType_Of_Requests
{
    public class UpdateType_Of_RequestsCommandValidator : AbstractValidator<UpdateType_Of_RequestsCommand>
    {
        public UpdateType_Of_RequestsCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_housing_and_communal_services);
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_healthcare);
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_transport);
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_education);
        }
    }
}
