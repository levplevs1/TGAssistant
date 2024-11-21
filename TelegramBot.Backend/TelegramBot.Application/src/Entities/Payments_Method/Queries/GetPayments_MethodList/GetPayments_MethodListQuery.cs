using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments_Method.Queries.GetPayments_MethodList
{
    public class GetPayments_MethodListQuery : IRequest<Payments_MethodListVm>
    {
        public int id_payments_method { get; set; }
    }
}
