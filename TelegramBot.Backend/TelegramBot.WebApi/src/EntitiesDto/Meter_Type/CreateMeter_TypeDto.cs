using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Meter_Type.Commands.CreateMeter_Type;
using TelegramBot.Application.src.Entities.Meter_Type.Queries.GetMeter_TypeDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Meter_Type
{
    public class CreateMeter_TypeDto : IMapWith<CreateMeter_TypeCommand>
    {
        public string meter_type_name { get; set; }

        public void MApping(Profile profile)
        {
            profile.CreateMap<CreateMeter_TypeDto, CreateMeter_TypeCommand>()
                .ForMember(entityDto => entityDto.meter_type_name,
                opt => opt.MapFrom(entity => entity.meter_type_name));
        }
    }
}
