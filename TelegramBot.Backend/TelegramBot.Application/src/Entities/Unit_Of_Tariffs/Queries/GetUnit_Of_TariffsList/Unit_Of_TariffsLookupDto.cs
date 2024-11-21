using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;

namespace TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Queries.GetUnit_Of_TariffsList
{
    public class Unit_Of_TariffsLookupDto : IMapWith<Domain.src.Entities.Unit_Of_Tariffs>
    {
        public int id_unit_of_tariffs { get; set; }
        public string unit_of_tariffs_name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Unit_Of_Tariffs, Unit_Of_TariffsLookupDto>()
                .ForMember(entityVm => entityVm.id_unit_of_tariffs,
                opt => opt.MapFrom(entity => entity.id_unit_of_tariffs))
                .ForMember(entityVm => entityVm.unit_of_tariffs_name,
                opt => opt.MapFrom(entity => entity.unit_of_tariffs_name));
        }
    }
}
