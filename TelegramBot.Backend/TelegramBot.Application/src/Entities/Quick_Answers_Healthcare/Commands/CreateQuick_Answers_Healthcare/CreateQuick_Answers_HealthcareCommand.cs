using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.CreateQuick_Answers_Healthcare
{
    public class CreateQuick_Answers_HealthcareCommand : IRequest<int>
    {
        public string quick_answer_healthcare_name { get; set; }
        public int? id_healthcare { get; set; }
    }
}
