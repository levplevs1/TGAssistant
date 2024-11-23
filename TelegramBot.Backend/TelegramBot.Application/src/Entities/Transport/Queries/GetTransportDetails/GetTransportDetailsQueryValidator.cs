using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Transport.Queries.GetTransportDetails
{
    public class GetTransportDetailsQueryValidator : AbstractValidator<GetTransportDetailsQuery>
    {
        public GetTransportDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_transport).NotEmpty();
        }
    }
}
