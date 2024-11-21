using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments_Method.Commands.UpdatePayments_Method
{
    public class UpdatePayments_MethodCommand : IRequest
    {
        public int id_payments_method { get; set; }
        public string payments_method_name { get; set; }
    }
}
