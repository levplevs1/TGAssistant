using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Tariffs.Commands.UpdateTariffs
{
    public class UpdateTariffsCommand : IRequest
    {
        public int id_tariffs { get; set; }
        public double tariff_value { get; set; }
    }
}
