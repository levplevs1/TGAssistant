using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.CreateArticles_Housing_Code;
using TelegramBot.Application.src.Entities.Service_Type.Commands.CreateService_Type;
using TelegramBot.Application.src.Entities.Service_Type.Queries.GetService_TypeDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Service_Type
{
    public class CreateService_TypeDto : IMapWith<CreateService_TypeCommand>
    {
        public string service_type_name { get; set; }
        public int id_housing_and_communal_services { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Service_Type, CreateService_TypeCommand>()
                .ForMember(entityDto => entityDto.service_type_name,
                opt => opt.MapFrom(entity => entity.service_type_name))
                .ForMember(entityDto => entityDto.id_housing_and_communal_services,
                opt => opt.MapFrom(entity => entity.id_housing_and_communal_services));
        }
    }
}
