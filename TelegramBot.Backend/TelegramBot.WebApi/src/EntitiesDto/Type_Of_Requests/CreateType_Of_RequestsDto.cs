using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Type_Of_Requests.Commands.CreateType_Of_Requests;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;

namespace TelegramBot.WebApi.src.EntitiesDto.Type_Of_Requests
{
    public class CreateType_Of_RequestsDto : IMapWith<CreateType_Of_RequestsCommand>
    {
        public int? id_housing_and_communal_services { get; set; }
        public int? id_healthcare { get; set; }
        public int? id_transport { get; set; }
        public int? id_education { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateType_Of_RequestsDto, CreateType_Of_RequestsCommand>()
                .ForMember(entityDto => entityDto.id_housing_and_communal_services,
                opt => opt.MapFrom(entity => entity.id_housing_and_communal_services))
                .ForMember(entityDto => entityDto.id_healthcare,
                opt => opt.MapFrom(entity => entity.id_healthcare))
                .ForMember(entityDto => entityDto.id_transport,
                opt => opt.MapFrom(entity => entity.id_transport))
                .ForMember(entityDto => entityDto.id_education,
                opt => opt.MapFrom(entity => entity.id_education));
        }
    }
}
