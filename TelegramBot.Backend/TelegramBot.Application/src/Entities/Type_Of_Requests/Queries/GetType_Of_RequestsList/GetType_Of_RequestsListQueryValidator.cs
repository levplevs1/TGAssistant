using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Type_Of_Requests.Queries.GetType_Of_RequestsList
{
    public class GetType_Of_RequestsListQueryValidator : AbstractValidator<GetType_Of_RequestsListQuery>
    {
        public GetType_Of_RequestsListQueryValidator()
        {
            RuleFor(entity => entity.id_type_of_requests);
        }
    }
}
