using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.User_Memory.Queries.GetUser_MemoryList
{
    public class User_MemoryListVm
    {
        public IList<User_MemoryLookupDto> User_Memory {  get; set; }
    }
}
