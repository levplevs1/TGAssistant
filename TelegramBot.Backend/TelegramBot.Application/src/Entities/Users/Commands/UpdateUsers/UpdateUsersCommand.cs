using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers
{
    public class UpdateUsersCommand : IRequest
    {
        public int id_users { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
    }
}
