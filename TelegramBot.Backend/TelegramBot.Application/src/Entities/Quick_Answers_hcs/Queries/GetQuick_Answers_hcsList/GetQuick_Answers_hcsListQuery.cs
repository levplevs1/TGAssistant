using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_hcs.Queries.GetQuick_Answers_hcsList
{
    public class GetQuick_Answers_hcsListQuery : IRequest<Quick_Answers_hcsListVm>
    {
        public int id_quick_answers_hcs { get; set; }
    }
}
