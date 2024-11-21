using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Queries.GetQuick_Answers_TransportDetails
{
    public class GetQuick_Answers_TransportDetailsQuery : IRequest<Quick_Answers_TransportDetailsVm>
    {
        public int id_quick_answer_transport { get; set; }
    }
}
