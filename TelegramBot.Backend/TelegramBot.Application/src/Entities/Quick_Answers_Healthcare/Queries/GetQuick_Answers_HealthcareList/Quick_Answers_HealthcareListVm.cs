using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Queries.GetQuick_Answers_HealthcareList
{
    public class Quick_Answers_HealthcareListVm
    {
        public IList<Quick_Answers_HealthcareLookupDto> Quick_Answers_Healthcare {  get; set; }
    }
}
