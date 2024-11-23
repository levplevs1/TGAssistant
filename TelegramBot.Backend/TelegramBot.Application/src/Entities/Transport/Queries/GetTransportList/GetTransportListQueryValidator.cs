using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Transport.Queries.GetTransportList
{
    public class GetTransportListQueryValidator : AbstractValidator<GetTransportListQuery>
    {
        public GetTransportListQueryValidator()
        {
            RuleFor(entity => entity.id_transport);
        }
    }
}
