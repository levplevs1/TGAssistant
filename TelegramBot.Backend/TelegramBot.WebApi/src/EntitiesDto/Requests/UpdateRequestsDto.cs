using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Requests.Commands.UpdateRequests;
using TelegramBot.Application.src.Entities.Requests.Queries.GetRequestsDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Requests
{
    public class UpdateRequestsDto : IMapWith<UpdateRequestsCommand>
    {
        public string request_text { get; set; }
        public string response { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateRequestsDto, UpdateRequestsCommand>()
                .ForMember(entityDto => entityDto.request_text,
                opt => opt.MapFrom(entity => entity.request_text))
                .ForMember(entityDto => entityDto.response,
                opt => opt.MapFrom(entity => entity.response));
        }
    }
}
