using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.UpdateQuick_Answers_hcs
{
    public class UpdateQuick_Answers_hcsCommand : IRequest
    {
        public int id_quick_answers_hcs { get; set; }
        public string quick_answers_hcs_name { get; set; }
        public string quick_answers_hcs_content { get; set; }
    }
}
