using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.User_Memory.Commands.UpdateUser_Memory
{
    public class UpdateUser_MemoryCommand : IRequest
    {
        public int id_user_memory { get; set; }
        public string content_memory {  get; set; }
    }
}
