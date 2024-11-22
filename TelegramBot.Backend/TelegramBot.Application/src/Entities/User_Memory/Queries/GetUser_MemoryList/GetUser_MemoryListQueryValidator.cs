using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.User_Memory.Queries.GetUser_MemoryList
{
    public class GetUser_MemoryListQueryValidator : AbstractValidator<GetUser_MemoryListQuery>
    {
        public GetUser_MemoryListQueryValidator()
        {
            RuleFor(entity => entity.id_user_memory);
        }
    }
}
