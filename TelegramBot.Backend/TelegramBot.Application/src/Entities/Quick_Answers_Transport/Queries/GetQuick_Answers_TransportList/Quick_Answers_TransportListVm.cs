using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Queries.GetQuick_Answers_TransportList
{
    public class Quick_Answers_TransportListVm
    {
        public IList<Quick_Answers_TransportLookupDto> Quick_Answers_Transport {  get; set; }
    }
}
