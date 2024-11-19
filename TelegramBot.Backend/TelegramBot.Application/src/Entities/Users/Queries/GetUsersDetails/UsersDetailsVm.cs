using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;

namespace TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails
{
    public class UsersDetailsVm : IMapWith<Domain.src.Entities.Users>
    {
        public int id_users { get; set; }
        public double id_telegram { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public DateTime created_at { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Users, UsersDetailsVm>()
                .ForMember(entityVm => entityVm.id_users,
                opt => opt.MapFrom(entity => entity.id_users))
                .ForMember(entityVm => entityVm.id_telegram,
                opt => opt.MapFrom(entity => entity.id_telegram))
                .ForMember(entityVm => entityVm.name,
                opt => opt.MapFrom(entity => entity.name))
                .ForMember(entityVm => entityVm.lastname,
                opt => opt.MapFrom(entity => entity.lastname))
                .ForMember(entityVm => entityVm.username,
                opt => opt.MapFrom(entity => entity.username))
                .ForMember(entityVm => entityVm.created_at,
                opt => opt.MapFrom(entity => entity.created_at));
        }
    }
}
