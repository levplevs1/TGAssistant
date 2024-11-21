using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.CreateQuick_Answers_Healthcare;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;

namespace TelegramBot.WebApi.src.EntitiesDto.Quick_Answers_Healthcare
{
    public class CreateQuick_Answers_HealthcareDto : IMapWith<CreateQuick_Answers_HealthcareCommand>
    {
        public string quick_answer_healthcare_name { get; set; }
        public int id_healthcare { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Quick_Answers_Healthcare, CreateQuick_Answers_HealthcareCommand>()
                .ForMember(entityDto => entityDto.quick_answer_healthcare_name,
                opt => opt.MapFrom(entity => entity.quick_answer_healthcare_name))
                .ForMember(entityDto => entityDto.id_healthcare,
                opt => opt.MapFrom(entity => entity.id_healthcare));
        }
    }
}
