using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.CreateUnit_Of_Tariffs;
using TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Queries.GetUnit_Of_TariffsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Unit_Of_Tariffs
{
    public class CreateUnit_Of_TariffsDto : IMapWith<CreateUnit_Of_TariffsCommand>
    {
        public string unit_of_tariffs_name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Unit_Of_Tariffs, Unit_Of_TariffsDetailsVm>()
                .ForMember(entityDto => entityDto.unit_of_tariffs_name,
                opt => opt.MapFrom(entity => entity.unit_of_tariffs_name));
        }
    }
}
