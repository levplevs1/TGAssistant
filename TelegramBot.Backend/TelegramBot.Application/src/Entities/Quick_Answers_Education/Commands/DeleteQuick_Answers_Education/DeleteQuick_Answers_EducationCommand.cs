using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.DeleteQuick_Answers_Education
{
    public class DeleteQuick_Answers_EducationCommand : IRequest
    {
        public int id_quick_answer_education { get; set; }
    }
}
