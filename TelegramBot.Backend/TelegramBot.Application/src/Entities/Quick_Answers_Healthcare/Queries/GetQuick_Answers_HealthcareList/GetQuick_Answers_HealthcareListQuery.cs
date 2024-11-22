using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Queries.GetQuick_Answers_HealthcareList
{
    public class GetQuick_Answers_HealthcareListQuery : IRequest<Quick_Answers_HealthcareListVm>
    {
        public int id_quick_answer_healthcare { get; set; }
    }
}
