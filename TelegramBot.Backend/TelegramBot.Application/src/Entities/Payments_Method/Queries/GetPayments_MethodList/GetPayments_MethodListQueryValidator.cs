using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments_Method.Queries.GetPayments_MethodList
{
    public class GetPayments_MethodListQueryValidator : AbstractValidator<GetPayments_MethodListQuery>
    {
        public GetPayments_MethodListQueryValidator()
        {
            RuleFor(entity => entity.id_payments_method);
        }
    }
}
