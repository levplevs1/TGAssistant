using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.CreateUnit_Of_Tariffs
{
    public class CreateUnit_Of_TariffsCommand : IRequest<int>
    {
        public string unit_of_tariffs_name { get; set; }
    }
}
