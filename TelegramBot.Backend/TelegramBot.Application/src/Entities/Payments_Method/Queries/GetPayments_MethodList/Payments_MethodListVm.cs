using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments_Method.Queries.GetPayments_MethodList
{
    public class Payments_MethodListVm
    {
        public IList<Payments_MethodLookupDto> Payments_Method {  get; set; }
    }
}
