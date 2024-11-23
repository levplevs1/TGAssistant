using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Service_Type.Commands.UpdateService_Type
{
    public class UpdateService_TypeCommandValidator : AbstractValidator<UpdateService_TypeCommand>
    {
        public UpdateService_TypeCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.service_type_name).MaximumLength(250);
        }
    }
}
