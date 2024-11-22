using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Education.Commands.UpdateEducation;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;

namespace TelegramBot.WebApi.src.EntitiesDto.Education
{
    public class UpdateEducationDto : IMapWith<UpdateEducationCommand>
    {
        public string text_of_request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Education, UpdateEducationCommand>()
                .ForMember(entityDto => entityDto.text_of_request,
                opt => opt.MapFrom(entity => entity.text_of_request));
        }
    }
}
