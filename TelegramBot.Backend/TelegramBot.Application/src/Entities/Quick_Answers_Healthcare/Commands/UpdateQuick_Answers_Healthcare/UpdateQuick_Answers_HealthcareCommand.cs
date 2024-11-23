using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.UpdateQuick_Answers_Healthcare
{
    public class UpdateQuick_Answers_HealthcareCommand : IRequest
    {
        public int id_quick_answer_healthcare { get; set; }
        public string quick_answer_healthcare_name { get; set; }
    }
}
