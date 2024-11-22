using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Education.Commands.CreateEducation;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;

namespace TelegramBot.WebApi.src.EntitiesDto.Education
{
    public class CreateEducationDto : IMapWith<CreateEducationCommand>
    {
        public string text_of_request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Education, CreateEducationCommand>()
                .ForMember(entityDto => entityDto.text_of_request,
                opt => opt.MapFrom(entity => entity.text_of_request));
        }
    }
}
