using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Healthcare.Commands.CreateHealthcare;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;

namespace TelegramBot.WebApi.src.EntitiesDto.Healthcare
{
    public class CreateHealthcareDto : IMapWith<CreateHealthcareCommand>
    {
        public string text_of_request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateHealthcareDto, CreateHealthcareCommand>()
                .ForMember(entityDto => entityDto.text_of_request,
                opt => opt.MapFrom(entity => entity.text_of_request));
        }
    }
}
