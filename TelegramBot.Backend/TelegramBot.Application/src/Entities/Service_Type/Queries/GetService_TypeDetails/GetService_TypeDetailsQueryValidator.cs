using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Service_Type.Queries.GetService_TypeDetails
{
    public class GetService_TypeDetailsQueryValidator : AbstractValidator<GetService_TypeDetailsQuery>
    {
        public GetService_TypeDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_service_type).NotEmpty();
        }
    }
}
