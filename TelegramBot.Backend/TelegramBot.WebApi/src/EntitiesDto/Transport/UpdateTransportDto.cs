using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Transport.Commands.CreateTransport;
using TelegramBot.Application.src.Entities.Transport.Commands.UpdateTransport;

namespace TelegramBot.WebApi.src.EntitiesDto.Transport
{
    public class UpdateTransportDto : IMapWith<UpdateTransportCommand>
    {
        public string text_of_request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTransportDto, UpdateTransportCommand>()
                .ForMember(entityDto => entityDto.text_of_request,
                opt => opt.MapFrom(entity => entity.text_of_request));
        }
    }
}
