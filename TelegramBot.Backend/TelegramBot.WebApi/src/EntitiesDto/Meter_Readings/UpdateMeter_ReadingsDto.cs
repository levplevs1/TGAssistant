using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Meter_Readings.Commands.UpdateMeter_Readings;
using TelegramBot.Application.src.Entities.Meter_Readings.Queries.GetMeter_ReadingsDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Meter_Readings
{
    public class UpdateMeter_ReadingsDto : IMapWith<UpdateMeter_ReadingsCommand>
    {
        public string readings_value { get; set; }
        public string previos_readings_value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Meter_Readings, Meter_ReadingsDetailsVm>()
                .ForMember(entityDto => entityDto.readings_value,
                opt => opt.MapFrom(entity => entity.readings_value))
                .ForMember(entityDto => entityDto.previos_readings_value,
                opt => opt.MapFrom(entity => entity.previos_readings_value));
        }
    }
}
