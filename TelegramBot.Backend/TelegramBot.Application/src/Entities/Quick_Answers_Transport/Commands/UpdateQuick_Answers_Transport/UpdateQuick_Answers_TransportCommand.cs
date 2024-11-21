using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.UpdateQuick_Answers_Transport
{
    public class UpdateQuick_Answers_TransportCommand : IRequest
    {
        public int id_quick_answer_transport { get; set; }
        public string quick_answer_transport_name { get; set; }
    }
}
