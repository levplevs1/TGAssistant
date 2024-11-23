using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.Application.src.Entities.Tariffs.Queries.GetTariffsDetails
{
    public class TariffsDetailsVm : IMapWith<Domain.src.Entities.Tariffs>
    {
        public int id_tariffs { get; set; }
        public DateTime effective_date { get; set; }
        public double tariff_value { get; set; }
        public int id_unit_of_tariffs { get; set; }
        public int id_service_type { get; set; }
        public int id_housing_and_communal_services { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Tariffs, TariffsDetailsVm>()
                .ForMember(entityVm => entityVm.id_tariffs,
                opt => opt.MapFrom(entity => entity.id_tariffs))
                .ForMember(entityVm => entityVm.effective_date,
                opt => opt.MapFrom(entity => entity.effective_date))
                .ForMember(entityVm => entityVm.tariff_value,
                opt => opt.MapFrom(entity => entity.tariff_value))
                .ForMember(entityVm => entityVm.id_unit_of_tariffs,
                opt => opt.MapFrom(entity => entity.id_unit_of_tariffs))
                .ForMember(entityVm => entityVm.id_service_type,
                opt => opt.MapFrom(entity => entity.id_service_type))
                .ForMember(entityVm => entityVm.id_housing_and_communal_services,
                opt => opt.MapFrom(entity => entity.id_housing_and_communal_services));
        }
    }
}
