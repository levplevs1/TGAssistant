using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments_Method.Queries.GetPayments_MethodDetails
{
    public class GetPayments_MethodDetailsQueryValidator : AbstractValidator<GetPayments_MethodDetailsQuery>
    {
        public GetPayments_MethodDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_payments_method).NotEmpty();
        }
    }
}
