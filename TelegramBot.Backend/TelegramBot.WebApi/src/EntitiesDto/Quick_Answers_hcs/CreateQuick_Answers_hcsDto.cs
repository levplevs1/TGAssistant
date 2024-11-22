using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.CreateQuick_Answers_hcs;
using TelegramBot.Application.src.Entities.Quick_Answers_hcs.Queries.GetQuick_Answers_hcsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Quick_Answers_hcs
{
    public class CreateQuick_Answers_hcsDto : IMapWith<CreateQuick_Answers_hcsCommand>
    {
        public string quick_answers_hcs_name { get; set; }
        public string quick_answers_hcs_content { get; set; }
        public int id_housing_and_communal_services { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateQuick_Answers_hcsDto, CreateQuick_Answers_hcsCommand>()
                .ForMember(entityDto => entityDto.quick_answers_hcs_name,
                opt => opt.MapFrom(entity => entity.quick_answers_hcs_name))
                .ForMember(entityDto => entityDto.quick_answers_hcs_content,
                opt => opt.MapFrom(entity => entity.quick_answers_hcs_content))
                .ForMember(entityDto => entityDto.id_housing_and_communal_services,
                opt => opt.MapFrom(entity => entity.id_housing_and_communal_services));
        }
    }
}
