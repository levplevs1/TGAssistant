using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Healthcare.Queries.GetHealthcareDetails
{
    public class GetHealthcareDetailsQuery : IRequest<HealthcareDetailsVm>
    {
        public int id_healthcare {  get; set; }
    }
}
