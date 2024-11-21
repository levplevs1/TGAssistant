using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Tariffs.Commands.CreateTariffs;
using TelegramBot.Application.src.Entities.Tariffs.Queries.GetTariffsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Tariffs
{
    public class CreateTariffsDto : IMapWith<CreateTariffsCommand>
    {
        public double tariff_value { get; set; }
        public int id_unit_of_tariffs { get; set; }
        public int id_service_type { get; set; }
        public int id_housing_and_communal_services { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Tariffs, CreateTariffsCommand>()
                .ForMember(entityDto => entityDto.tariff_value,
                opt => opt.MapFrom(entity => entity.tariff_value))
                .ForMember(entityDto => entityDto.id_unit_of_tariffs,
                opt => opt.MapFrom(entity => entity.id_unit_of_tariffs))
                .ForMember(entityDto => entityDto.id_service_type,
                opt => opt.MapFrom(entity => entity.id_service_type))
                .ForMember(entityDto => entityDto.id_housing_and_communal_services,
                opt => opt.MapFrom(entity => entity.id_housing_and_communal_services));
        }
    }
}
