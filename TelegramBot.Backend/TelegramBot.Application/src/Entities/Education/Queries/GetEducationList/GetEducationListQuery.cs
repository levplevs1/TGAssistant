using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Education.Queries.GetEducationList
{
    public class GetEducationListQuery : IRequest<EducationListVm>
    {
        public int id_education { get; set; }
    }
}
