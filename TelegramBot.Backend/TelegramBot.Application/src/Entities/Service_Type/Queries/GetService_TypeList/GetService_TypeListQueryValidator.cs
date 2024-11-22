using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Service_Type.Queries.GetService_TypeList
{
    public class GetService_TypeListQueryValidator : AbstractValidator<GetService_TypeListQuery>
    {
        public GetService_TypeListQueryValidator()
        {
            RuleFor(entity => entity.id_service_type);
        }
    }
}
