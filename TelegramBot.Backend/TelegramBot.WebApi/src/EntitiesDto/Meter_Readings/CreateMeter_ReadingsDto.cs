using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.CreateArticles_Housing_Code;
using TelegramBot.Application.src.Entities.Meter_Readings.Commands.CreateMeter_Readings;
using TelegramBot.Application.src.Entities.Meter_Readings.Queries.GetMeter_ReadingsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Meter_Readings
{
    public class CreateMeter_ReadingsDto : IMapWith<CreateMeter_ReadingsCommand>
    {
        public string readings_value { get; set; }
        public string previos_readings_value { get; set; }
        public int id_meters { get; set; }
        public int id_housing_and_communal_services { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Meter_Readings, CreateMeter_ReadingsCommand>()
                .ForMember(entityDto => entityDto.readings_value,
                opt => opt.MapFrom(entity => entity.readings_value))
                .ForMember(entityDto => entityDto.previos_readings_value,
                opt => opt.MapFrom(entity => entity.previos_readings_value))
                .ForMember(entityDto => entityDto.id_meters,
                opt => opt.MapFrom(entity => entity.id_meters))
                .ForMember(entityDto => entityDto.id_housing_and_communal_services,
                opt => opt.MapFrom(entity => entity.id_housing_and_communal_services));
        }
    }
}
