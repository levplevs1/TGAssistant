using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.UsersDto
{
    public class CreateUsersDto : IMapWith<CreateUsersCommand>
    {
        public double id_telegram {  get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Users, CreateUsersCommand>()
                .ForMember(entityDto => entityDto.id_telegram,
                opt => opt.MapFrom(entity => entity.id_telegram))
                .ForMember(entityDto => entityDto.name,
                opt => opt.MapFrom(entity => entity.name))
                .ForMember(entityDto => entityDto.lastname,
                opt => opt.MapFrom(entity => entity.lastname))
                .ForMember(entityDto => entityDto.username,
                opt => opt.MapFrom(entity => entity.username));
        }
    }
}
