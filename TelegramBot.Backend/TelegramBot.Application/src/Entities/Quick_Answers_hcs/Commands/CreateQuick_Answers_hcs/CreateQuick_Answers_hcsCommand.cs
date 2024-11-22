using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.CreateQuick_Answers_hcs
{
    public class CreateQuick_Answers_hcsCommand : IRequest<int>
    {
        public string quick_answers_hcs_name { get; set; }
        public string quick_answers_hcs_content { get; set; }
        public int id_housing_and_communal_services { get; set; }
    }
}
