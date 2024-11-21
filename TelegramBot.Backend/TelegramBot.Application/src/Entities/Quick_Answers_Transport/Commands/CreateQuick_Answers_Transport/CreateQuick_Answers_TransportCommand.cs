using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.CreateQuick_Answers_Transport
{
    public class CreateQuick_Answers_TransportCommand : IRequest<int>
    {
        public string quick_answer_transport_name { get; set; }
        public int id_transport { get; set; }
    }
}
