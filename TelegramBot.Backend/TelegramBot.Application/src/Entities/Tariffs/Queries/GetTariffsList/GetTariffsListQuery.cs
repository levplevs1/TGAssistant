using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Tariffs.Queries.GetTariffsList
{
    public class GetTariffsListQuery : IRequest<TariffsListVm>
    {
        public int id_tariffs {  get; set; }
    }
}
