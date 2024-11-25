﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments.Queries.GetPaymentsDetails
{
    public class GetPaymentsDetailsQuery : IRequest<PaymentsDetailsVm>
    {
        public int id_payments {  get; set; }
    }
}