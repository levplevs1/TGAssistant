using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Type_Of_Requests.Queries.GetType_Of_RequestsList
{
    public class Type_Of_RequestsListVm
    {
        public IList<Type_Of_RequestsLookupDto> Type_Of_Requests {  get; set; }
    }
}
