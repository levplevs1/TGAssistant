using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails
{
    public class GetUsersDetailsQueryValidator : AbstractValidator<GetUsersDetailsQuery>
    {
        public GetUsersDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_users).NotEmpty();
        }
    }
}
