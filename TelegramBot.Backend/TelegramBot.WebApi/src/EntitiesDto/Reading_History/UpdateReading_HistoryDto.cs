using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Reading_History.Commands.UpdateReading_History;
using TelegramBot.Application.src.Entities.Reading_History.Queries.GetReading_HistoryDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Reading_History
{
    public class UpdateReading_HistoryDto : IMapWith<UpdateReading_HistoryCommand>
    {
        public string reading_value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Reading_History, UpdateReading_HistoryCommand>()
                .ForMember(entityDto => entityDto.reading_value,
                opt => opt.MapFrom(entity => entity.reading_value));
        }
    }
}
