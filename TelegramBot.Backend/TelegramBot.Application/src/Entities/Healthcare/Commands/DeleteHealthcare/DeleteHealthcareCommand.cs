using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Healthcare.Commands.DeleteHealthcare
{
    public class DeleteHealthcareCommand : IRequest
    {
        public int id_healthcare {  get; set; }
    }
}
