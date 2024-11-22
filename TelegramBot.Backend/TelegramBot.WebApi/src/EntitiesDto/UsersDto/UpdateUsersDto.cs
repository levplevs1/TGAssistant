using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.UsersDto
{
    public class UpdateUsersDto : IMapWith<UpdateUsersCommand>
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUsersDto, UpdateUsersCommand>()
                .ForMember(entityDto => entityDto.name,
                opt => opt.MapFrom(entity => entity.name))
                .ForMember(entityDto => entityDto.lastname,
                opt => opt.MapFrom(entity => entity.lastname))
                .ForMember(entityDto => entityDto.username,
                opt => opt.MapFrom(entity => entity.username));
        }
    }
}
