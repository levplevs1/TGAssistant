using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.CreateArticles_Housing_Code;
using TelegramBot.Application.src.Entities.Reading_History.Commands.CreateReading_History;
using TelegramBot.Application.src.Entities.Reading_History.Queries.GetReading_HistoryDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Reading_History
{
    public class CreateReading_HistoryDto : IMapWith<CreateReading_HistoryCommand>
    {
        public string reading_value { get; set; }
        public int id_meters { get; set; }
        public int id_housing_and_communal_services { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Reading_History, CreateReading_HistoryCommand>()
                .ForMember(entityDto => entityDto.reading_value,
                opt => opt.MapFrom(entity => entity.reading_value))
                .ForMember(entityDto => entityDto.id_meters,
                opt => opt.MapFrom(entity => entity.id_meters))
                .ForMember(entityDto => entityDto.id_housing_and_communal_services,
                opt => opt.MapFrom(entity => entity.id_housing_and_communal_services));
        }
    }
}
