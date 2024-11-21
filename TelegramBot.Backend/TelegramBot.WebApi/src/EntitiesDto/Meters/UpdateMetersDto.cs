using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Meters.Commands.UpdateMeters;
using TelegramBot.Application.src.Entities.Meters.Queries.GetMetersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Meters
{
    public class UpdateMetersDto : IMapWith<UpdateMetersCommand>
    {
        public int id_meters { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Meters, MetersDetailsVm>()
                .ForMember(entityDto => entityDto.id_meters,
                opt => opt.MapFrom(entity => entity.id_meters));
        }
    }
}
