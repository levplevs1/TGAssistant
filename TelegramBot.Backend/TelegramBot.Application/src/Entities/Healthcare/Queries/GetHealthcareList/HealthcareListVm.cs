using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Healthcare.Queries.GetHealthcareList
{
    public class HealthcareListVm
    {
        public IList<HealthcareLookupDto> Healthcare {  get; set; }
    }
}
