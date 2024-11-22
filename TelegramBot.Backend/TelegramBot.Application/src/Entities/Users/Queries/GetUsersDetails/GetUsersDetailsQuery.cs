using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails
{
    public class GetUsersDetailsQuery : IRequest<UsersDetailsVm>
    {
        public int id_users {  get; set; }
    }
}
