using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Tariffs.Commands.UpdateTariffs;
using TelegramBot.Application.src.Entities.Tariffs.Queries.GetTariffsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Tariffs
{
    public class UpdateTariffsDto : IMapWith<UpdateTariffsCommand>
    {
        public double tariff_value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Tariffs, TariffsDetailsVm>()
                .ForMember(entityDto => entityDto.tariff_value,
                opt => opt.MapFrom(entity => entity.tariff_value));
        }
    }
}
