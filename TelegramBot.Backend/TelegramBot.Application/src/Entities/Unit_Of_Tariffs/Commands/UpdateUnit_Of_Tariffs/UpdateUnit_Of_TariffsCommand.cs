using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.UpdateUnit_Of_Tariffs
{
    public class UpdateUnit_Of_TariffsCommand : IRequest
    {
        public int id_unit_of_tariffs { get; set; }
        public string unit_of_tariffs_name { get; set; }
    }
}
