using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Meters.Commands.CreateMeters;
using TelegramBot.Application.src.Entities.Meters.Queries.GetMetersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Meters
{
    public class CreateMetersDto : IMapWith<CreateMetersCommand>
    {
        public int id_meter_type { get; set; }
        public int id_users { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Meters, MetersDetailsVm>()
                .ForMember(entityDto => entityDto.id_meter_type,
                opt => opt.MapFrom(entity => entity.id_meter_type))
                .ForMember(entityDto => entityDto.id_users,
                opt => opt.MapFrom(entity => entity.id_users));
        }
    }
}
