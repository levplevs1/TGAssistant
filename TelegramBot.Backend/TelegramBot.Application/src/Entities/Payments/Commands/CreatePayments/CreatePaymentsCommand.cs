using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments.Commands.CreatePayments
{
    public class CreatePaymentsCommand : IRequest<int>
    {
        public DateTime? payments_date { get; set; }
        public double? amount { get; set; }
        public int? id_users { get; set; }
        public int? id_payments_method { get; set; }
        public int? id_service_type { get; set; }
    }
}
