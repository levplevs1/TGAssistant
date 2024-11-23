using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments_Method.Commands.DeletePayments_Method
{
    public class DeletePayments_MethodCommand : IRequest
    {
        public int id_payments_method {  get; set; }
    }
}
