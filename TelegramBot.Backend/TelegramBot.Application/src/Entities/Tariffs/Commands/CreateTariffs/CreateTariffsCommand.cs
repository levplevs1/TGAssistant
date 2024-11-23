using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Tariffs.Commands.CreateTariffs
{
    public class CreateTariffsCommand : IRequest<int>
    {
        public DateTime effective_date { get; set; }
        public double tariff_value { get; set; }
        public int id_unit_of_tariffs { get; set; }
        public int id_service_type { get; set; }
        public int id_housing_and_communal_services { get; set; }
    }
}
