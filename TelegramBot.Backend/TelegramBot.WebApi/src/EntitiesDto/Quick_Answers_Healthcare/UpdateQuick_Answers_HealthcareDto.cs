using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.CreateQuick_Answers_Healthcare;
using TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.UpdateQuick_Answers_Healthcare;

namespace TelegramBot.WebApi.src.EntitiesDto.Quick_Answers_Healthcare
{
    public class UpdateQuick_Answers_HealthcareDto : IMapWith<UpdateQuick_Answers_HealthcareCommand>
    {
        public string quick_answer_healthcare_name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Quick_Answers_Healthcare, UpdateQuick_Answers_HealthcareCommand>()
                .ForMember(entityDto => entityDto.quick_answer_healthcare_name,
                opt => opt.MapFrom(entity => entity.quick_answer_healthcare_name));
        }
    }
}
