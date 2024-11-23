using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Education.Commands.UpdateEducation
{
    public class UpdateEducationCommand : IRequest
    {
        public int id_education { get; set; }
        public string text_of_request { get; set; }
    }
}
