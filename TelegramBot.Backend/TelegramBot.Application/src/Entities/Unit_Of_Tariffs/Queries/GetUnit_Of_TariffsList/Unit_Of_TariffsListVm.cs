using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Queries.GetUnit_Of_TariffsList
{
    public class Unit_Of_TariffsListVm
    {
        public IList<Unit_Of_TariffsLookupDto> Unit_Of_Tariffs {  get; set; }
    }
}
