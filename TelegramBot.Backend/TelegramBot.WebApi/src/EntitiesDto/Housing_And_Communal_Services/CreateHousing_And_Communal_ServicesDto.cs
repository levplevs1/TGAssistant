using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Commands.CreateHousing_And_Communal_Services;
using TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Queries.GetHousing_And_Communal_ServicesDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Housing_And_Communal_Services
{
    public class CreateHousing_And_Communal_ServicesDto : IMapWith<CreateHousing_And_Communal_ServicesCommand>
    {
        public string text_of_request { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Housing_And_Communal_Services, CreateHousing_And_Communal_ServicesCommand>()
                .ForMember(entityDto => entityDto.text_of_request,
                opt => opt.MapFrom(entity => entity.text_of_request));
        }
    }
}
