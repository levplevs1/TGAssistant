using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;

namespace TelegramBot.Application.src.Entities.User_Memory.Queries.GetUser_MemoryList
{
    public class User_MemoryLookupDto : IMapWith<Domain.src.Entities.User_Memory>
    {
        public int id_user_memory { get; set; }
        public string content_memory { get; set; }
        public int id_users { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.User_Memory, User_MemoryLookupDto>()
                .ForMember(entityVm => entityVm.id_user_memory,
                opt => opt.MapFrom(entity => entity.id_user_memory))
                .ForMember(entityVm => entityVm.content_memory,
                opt => opt.MapFrom(entity => entity.content_memory))
                .ForMember(entityVm => entityVm.id_users,
                opt => opt.MapFrom(entity => entity.id_users));
        }
    }
}
