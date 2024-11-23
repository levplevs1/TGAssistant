using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Service_Type.Commands.CreateService_Type
{
    public class CreateService_TypeCommandValidator : AbstractValidator<CreateService_TypeCommand>
    {
        public CreateService_TypeCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.id_housing_and_communal_services);
            RuleFor(createEntityCommand =>
            createEntityCommand.service_type_name).MaximumLength(250);;
        }
    }
}
