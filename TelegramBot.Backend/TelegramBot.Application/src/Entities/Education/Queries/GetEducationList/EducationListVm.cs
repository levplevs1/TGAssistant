using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Education.Queries.GetEducationList
{
    public class EducationListVm
    {
        public IList<EducationLookupDto> Education {  get; set; }
    }
}
