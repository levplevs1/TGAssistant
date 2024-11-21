using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Type_Of_Requests.Queries.GetType_Of_RequestsDetails
{
    public class GetType_Of_RequestsDetailsQueryValidator : AbstractValidator<GetType_Of_RequestsDetailsQuery>
    {
        public GetType_Of_RequestsDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_type_of_requests).NotEmpty();
        }
    }
}
