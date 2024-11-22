using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.UpdateQuick_Answers_Education
{
    public class UpdateQuick_Answers_EducationCommand : IRequest
    {
        public int id_quick_answer_education { get; set; }
        public string quick_answer_education_name { get; set; }
    }
}
