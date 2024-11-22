using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.UpdateQuick_Answers_Education;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;

namespace TelegramBot.WebApi.src.EntitiesDto.Quick_Answers_Education
{
    public class UpdateQuick_Answers_EducationDto : IMapWith<UpdateQuick_Answers_EducationCommand>
    {
        public string quick_answer_education_name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateQuick_Answers_EducationDto, UpdateQuick_Answers_EducationCommand>()
                .ForMember(entityDto => entityDto.quick_answer_education_name,
                opt => opt.MapFrom(entity => entity.quick_answer_education_name));
        }
    }
}
