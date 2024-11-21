using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.User_Memory.Commands.UpdateUser_Memory;
using TelegramBot.Application.src.Entities.User_Memory.Queries.GetUser_MemoryDetails;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.User_Memory
{
    public class UpdateUser_MemoryDto : IMapWith<UpdateUser_MemoryCommand>
    {
        public string content_memory { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.User_Memory, UpdateUser_MemoryCommand>()
                .ForMember(entityDto => entityDto.content_memory,
                opt => opt.MapFrom(entity => entity.content_memory));
        }
    }
}
