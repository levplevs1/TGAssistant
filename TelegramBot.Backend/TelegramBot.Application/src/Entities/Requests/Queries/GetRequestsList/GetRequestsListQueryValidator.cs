using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Requests.Queries.GetRequestList
{
    public class GetRequestsListQueryValidator : AbstractValidator<GetRequestsListQuery>
    {
        public GetRequestsListQueryValidator()
        {
            RuleFor(entity => entity.id_requests);
        }
    }
}
