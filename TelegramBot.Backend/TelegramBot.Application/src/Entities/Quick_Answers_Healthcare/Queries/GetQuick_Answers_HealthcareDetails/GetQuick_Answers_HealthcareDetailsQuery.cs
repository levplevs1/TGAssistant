using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Queries.GetQuick_Answers_HealthcareDetails
{
    public class GetQuick_Answers_HealthcareDetailsQuery : IRequest<Quick_Answers_HealthcareDetailsVm>
    {
        public int id_quick_answer_healthcare { get; set; }
    }
}
