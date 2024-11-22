using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Healthcare.Commands.CreateHealthcare;
using TelegramBot.Application.src.Entities.Healthcare.Commands.UpdateHealthcare;

namespace TelegramBot.WebApi.src.EntitiesDto.Healthcare
{
    public class UpdateHealthcareDto : IMapWith<UpdateHealthcareCommand>
    {
        public string text_of_request { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateHealthcareDto, UpdateHealthcareCommand>()
                .ForMember(entityDto => entityDto.text_of_request,
                opt => opt.MapFrom(entity => entity.text_of_request));
        }
    }
}
