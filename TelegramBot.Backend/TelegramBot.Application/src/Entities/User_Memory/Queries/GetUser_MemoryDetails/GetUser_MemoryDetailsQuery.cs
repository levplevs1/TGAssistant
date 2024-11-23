using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.User_Memory.Queries.GetUser_MemoryDetails
{
    public class GetUser_MemoryDetailsQuery : IRequest<User_MemoryDetailsVm>
    {
        public int id_user_memory {  get; set; }
    }
}
