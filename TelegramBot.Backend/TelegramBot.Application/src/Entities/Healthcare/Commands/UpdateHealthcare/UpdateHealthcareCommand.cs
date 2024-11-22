using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Healthcare.Commands.UpdateHealthcare
{
    public class UpdateHealthcareCommand : IRequest
    {
        public int id_healthcare { get; set; }
        public string text_of_request { get; set; }
    }
}
