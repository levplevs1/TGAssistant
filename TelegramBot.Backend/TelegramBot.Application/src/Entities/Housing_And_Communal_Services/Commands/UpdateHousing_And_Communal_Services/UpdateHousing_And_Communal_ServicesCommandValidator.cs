using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Commands.UpdateHousing_And_Communal_Services
{
    public class UpdateHousing_And_Communal_ServicesCommandValidator : AbstractValidator<UpdateHousing_And_Communal_ServicesCommand>
    {
        public UpdateHousing_And_Communal_ServicesCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.text_of_request).MaximumLength(250);
        }
    }
}
