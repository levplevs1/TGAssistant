using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Tariffs.Queries.GetTariffsDetails
{
    public class GetTariffsDetailsQuery : IRequest<TariffsDetailsVm>
    {
        public int id_tariffs {  get; set; }
    }
}
