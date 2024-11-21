using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Education.Commands.DeleteEducation
{
    public class DeleteEducationCommand : IRequest
    {
        public int id_education { get; set; }
    }
}
