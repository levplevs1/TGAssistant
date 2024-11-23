using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Service_Type.Queries.GetService_TypeList
{
    public class Service_TypeListVm
    {
        public IList<Service_TypeLookupDto> Service_Type { get; set; }
    }
}
