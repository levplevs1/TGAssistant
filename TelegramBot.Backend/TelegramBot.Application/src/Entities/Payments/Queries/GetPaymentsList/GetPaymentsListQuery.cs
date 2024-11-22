using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments.Queries.GetPaymentsList
{
    public class GetPaymentsListQuery : IRequest<PaymentsListVm>
    {
        public int id_payments {  get; set; }
    }
}
