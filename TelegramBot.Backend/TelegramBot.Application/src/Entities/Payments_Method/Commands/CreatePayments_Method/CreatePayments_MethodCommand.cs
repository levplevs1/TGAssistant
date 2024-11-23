using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments_Method.Commands.CreatePayments_Method
{
    public class CreatePayments_MethodCommand : IRequest<int>
    {
        public string payments_method_name { get; set; }
    }
}
