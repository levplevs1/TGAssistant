using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.User_Memory.Commands.DeleteUser_Memory
{
    public class DeleteUser_MemoryCommand : IRequest
    {
        public int id_user_memory {  get; set; }
    }
}
