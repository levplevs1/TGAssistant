using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Requests.Commands.CreateRequest;
using TelegramBot.Application.src.Entities.Requests.Queries.GetRequestsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Domain.src.Entities;
using TelegramBot.WebApi.src.EntitiesDto.Reading_History;

namespace TelegramBot.WebApi.src.EntitiesDto.Requests
{
    public class CreateRequestsDto : IMapWith<CreateRequestsCommand>
    {
        public string request_text { get; set; }
        public string response { get; set; }
        public int id_type_of_requests { get; set; }
        public int id_users { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRequestsDto, CreateRequestsCommand>()
                .ForMember(entityDto => entityDto.request_text,
                opt => opt.MapFrom(entity => entity.request_text))
                .ForMember(entityDto => entityDto.response,
                opt => opt.MapFrom(entity => entity.response))
                .ForMember(entityDto => entityDto.id_type_of_requests,
                opt => opt.MapFrom(entity => entity.id_type_of_requests))
                .ForMember(entityDto => entityDto.id_users,
                opt => opt.MapFrom(entity => entity.id_users));
        }
    }
}
