using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Meter_Type.Commands.UpdateMeter_Type;
using TelegramBot.Application.src.Entities.Meter_Type.Queries.GetMeter_TypeDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Meter_Type
{
    public class UpdateMeter_TypeDto : IMapWith<UpdateMeter_TypeCommand>
    {
        public string meter_type_name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Meter_Type, UpdateMeter_TypeCommand>()
                .ForMember(entityDto => entityDto.meter_type_name,
                opt => opt.MapFrom(entity => entity.meter_type_name));
        }
    }
}
