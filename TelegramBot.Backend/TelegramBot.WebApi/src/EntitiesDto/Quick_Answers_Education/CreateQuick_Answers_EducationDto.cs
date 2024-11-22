using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.CreateQuick_Answers_Education;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;

namespace TelegramBot.WebApi.src.EntitiesDto.Quick_Answers_Education
{
    public class CreateQuick_Answers_EducationDto : IMapWith<CreateQuick_Answers_EducationCommand>
    {
        public string quick_answer_education_name { get; set; }
        public int id_education { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateQuick_Answers_EducationDto, CreateQuick_Answers_EducationCommand>()
                .ForMember(entityDto => entityDto.quick_answer_education_name,
                opt => opt.MapFrom(entity => entity.quick_answer_education_name))
                .ForMember(entityDto => entityDto.id_education,
                opt => opt.MapFrom(entity => entity.id_education));
        }
    }
}
