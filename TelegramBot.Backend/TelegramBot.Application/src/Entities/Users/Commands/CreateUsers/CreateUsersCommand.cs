using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Users.Commands.CreateUsers
{
    public class CreateUsersCommand : IRequest<int>
    {
        public double id_telegram {  get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public DateTime created_at { get; set; }
    }
}
