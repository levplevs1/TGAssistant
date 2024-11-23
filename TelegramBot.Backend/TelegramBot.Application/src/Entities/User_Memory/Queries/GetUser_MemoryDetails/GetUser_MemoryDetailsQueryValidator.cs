using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.User_Memory.Queries.GetUser_MemoryDetails
{
    public class GetUser_MemoryDetailsQueryValidator : AbstractValidator<GetUser_MemoryDetailsQuery>
    {
        public GetUser_MemoryDetailsQueryValidator()
        {
            RuleFor(note => note.id_user_memory).NotEmpty();
        }
    }
}
