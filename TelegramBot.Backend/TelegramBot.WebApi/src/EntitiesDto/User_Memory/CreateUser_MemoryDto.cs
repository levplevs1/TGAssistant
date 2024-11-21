using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.User_Memory.Commands.CreateUser_Memory;
using TelegramBot.Application.src.Entities.User_Memory.Queries.GetUser_MemoryDetails;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;

namespace TelegramBot.WebApi.src.EntitiesDto.User_Memory
{
    public class CreateUser_MemoryDto : IMapWith<CreateUser_MemoryCommand>
    {
        public string content_memory { get; set; }
        public int id_users { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.User_Memory, CreateUser_MemoryCommand>()
                .ForMember(entityDto => entityDto.content_memory,
                opt => opt.MapFrom(entity => entity.content_memory))
                .ForMember(entityDto => entityDto.id_users,
                opt => opt.MapFrom(entity => entity.id_users));
        }
    }
}
