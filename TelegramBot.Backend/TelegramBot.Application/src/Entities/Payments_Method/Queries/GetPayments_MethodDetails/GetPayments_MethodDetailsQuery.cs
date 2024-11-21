using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments_Method.Queries.GetPayments_MethodDetails
{
    public class GetPayments_MethodDetailsQuery : IRequest<Payments_MethodDetailsVm>
    {
        public int id_payments_method {  get; set; }
    }
}
