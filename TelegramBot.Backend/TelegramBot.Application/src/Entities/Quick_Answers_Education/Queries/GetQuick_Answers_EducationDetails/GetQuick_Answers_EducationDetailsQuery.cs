using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Education.Queries.GetQuick_Answers_EducationDetails
{
    public class GetQuick_Answers_EducationDetailsQuery : IRequest<Quick_Answers_EducationDetailsVm>
    {
        public int id_quick_answer_education { get; set; }
    }
}
