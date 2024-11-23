using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Healthcare.Queries.GetHealthcareList
{
    public class GetHealthcareListQuery : IRequest<HealthcareListVm>
    {
        public int id_healthcare {  get; set; } 
    }
}
