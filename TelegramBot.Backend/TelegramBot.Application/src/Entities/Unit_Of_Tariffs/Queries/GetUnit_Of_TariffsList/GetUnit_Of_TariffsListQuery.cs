using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Queries.GetUnit_Of_TariffsList
{
    public class GetUnit_Of_TariffsListQuery : IRequest<Unit_Of_TariffsListVm>
    {
        public int id_unit_of_tariffs {  get; set; }
    }
}
