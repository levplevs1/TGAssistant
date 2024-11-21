using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Education.Queries.GetEducationDetails
{
    public class GetEducationDetailsQuery : IRequest<EducationDetailsVm>
    {
        public int id_education { get; set; }
    }
}
