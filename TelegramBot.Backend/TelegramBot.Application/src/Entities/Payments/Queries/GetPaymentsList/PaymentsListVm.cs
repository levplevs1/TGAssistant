using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments.Queries.GetPaymentsList
{
    public class PaymentsListVm
    {
        public IList<PaymentsLookupDto> Payments {  get; set; }
    }
}
