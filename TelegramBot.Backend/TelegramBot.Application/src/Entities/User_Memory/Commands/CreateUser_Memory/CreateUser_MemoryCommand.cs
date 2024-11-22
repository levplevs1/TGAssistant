using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.User_Memory.Commands.CreateUser_Memory
{
    public class CreateUser_MemoryCommand : IRequest<int>
    {
        public string content_memory { get; set; }
        public int id_users { get; set; }
    }
}
