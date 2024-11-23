using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.CreateQuick_Answers_Education
{
    public class CreateQuick_Answers_EducationCommand : IRequest<int>
    {
        public string quick_answer_education_name { get; set; }
        public int id_education { get; set; }
    }
}
