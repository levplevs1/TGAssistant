using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Users.Queries.GetUsersList
{
    public class UsersListVm
    {
        public IList<UsersLookupDto> Users {  get; set; }
    }
}
