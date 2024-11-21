using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.UpdateQuick_Answers_Transport;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;

namespace TelegramBot.WebApi.src.EntitiesDto.Quick_Answers_Transport
{
    public class UpdateQuick_Answers_TransportDto : IMapWith<UpdateQuick_Answers_TransportCommand>
    {
        public string quick_answer_transport_name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Quick_Answers_Transport, UpdateQuick_Answers_TransportCommand>()
                .ForMember(entityDto => entityDto.quick_answer_transport_name,
                opt => opt.MapFrom(entity => entity.quick_answer_transport_name));
        }
    }
}
