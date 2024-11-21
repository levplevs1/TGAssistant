using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Transport.Queries.GetTransportList
{
    public class TransportListVm
    {
        public IList<TransportLookupDto> Transport {  get; set; }
    }
}
