using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.DeleteQuick_Answers_Transport
{
    public class DeleteQuick_Answers_TransportCommand : IRequest
    {
        public int id_quick_answer_transport { get; set; }
    }
}
