using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments.Commands.UpdatePayments
{
    public class UpdatePaymentsCommand : IRequest
    {
        public int id_payments { get; set; }
        public double amount { get; set; }
    }
}
