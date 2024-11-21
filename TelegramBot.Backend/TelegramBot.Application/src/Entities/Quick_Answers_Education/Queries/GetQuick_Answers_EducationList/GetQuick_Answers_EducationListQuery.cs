using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Education.Queries.GetQuick_Answers_EducationList
{
    public class GetQuick_Answers_EducationListQuery : IRequest<Quick_Answers_EducationListVm>
    {
        public int id_quick_answer_education { get; set; }

    }
}
