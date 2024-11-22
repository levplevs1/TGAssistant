using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Service_Type.Commands.UpdateService_Type;
using TelegramBot.Application.src.Entities.Service_Type.Queries.GetService_TypeDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Service_Type
{
    public class UpdateService_TypeDto : IMapWith<UpdateService_TypeCommand>
    {
        public string service_type_name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Service_Type, UpdateService_TypeCommand>()
                .ForMember(entityDto => entityDto.service_type_name,
                opt => opt.MapFrom(entity => entity.service_type_name));
        }
    }
}
