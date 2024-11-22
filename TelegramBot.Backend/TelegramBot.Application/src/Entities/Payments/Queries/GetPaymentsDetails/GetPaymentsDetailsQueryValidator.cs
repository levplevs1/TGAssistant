using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments.Queries.GetPaymentsDetails
{
    public class GetPaymentsDetailsQueryValidator : AbstractValidator<GetPaymentsDetailsQuery>
    {
        public GetPaymentsDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_payments).NotEmpty();
        }
    }
}
