using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.CreateQuick_Answers_hcs;
using TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.CreateQuick_Answers_Transport;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;

namespace TelegramBot.WebApi.src.EntitiesDto.Quick_Answers_Transport
{
    public class CreateQuick_Answers_TransportDto : IMapWith<CreateQuick_Answers_TransportCommand>
    {
        public string quick_answer_transport_name { get; set; }
        public int id_transport { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateQuick_Answers_TransportDto, CreateQuick_Answers_TransportCommand>()
                .ForMember(entityDto => entityDto.quick_answer_transport_name,
                opt => opt.MapFrom(entity => entity.quick_answer_transport_name))
                .ForMember(entityDto => entityDto.id_transport,
                opt => opt.MapFrom(entity => entity.id_transport));
        }
    }
}
