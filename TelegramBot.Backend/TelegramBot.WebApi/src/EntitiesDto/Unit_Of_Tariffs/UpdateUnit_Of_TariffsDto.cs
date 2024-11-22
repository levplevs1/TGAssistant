using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.UpdateUnit_Of_Tariffs;
using TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Queries.GetUnit_Of_TariffsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Unit_Of_Tariffs
{
    public class UpdateUnit_Of_TariffsDto : IMapWith<UpdateUnit_Of_TariffsCommand>
    {
        public string unit_of_tariffs_name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUnit_Of_TariffsDto, UpdateUnit_Of_TariffsCommand>()
                .ForMember(entityDto => entityDto.unit_of_tariffs_name,
                opt => opt.MapFrom(entity => entity.unit_of_tariffs_name));
        }
    }
}
