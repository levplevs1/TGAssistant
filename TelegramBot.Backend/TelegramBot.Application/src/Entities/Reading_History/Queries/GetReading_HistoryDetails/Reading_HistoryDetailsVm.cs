using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.Application.src.Entities.Reading_History.Queries.GetReading_HistoryDetails
{
    public class Reading_HistoryDetailsVm : IMapWith<Domain.src.Entities.Reading_History>
    {
        public int id_reading_history { get; set; }
        public DateTime reading_date { get; set; }
        public string reading_value { get; set; }
        public int id_meters { get; set; }
        public int id_housing_and_communal_services { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Reading_History, Reading_HistoryDetailsVm>()
                .ForMember(entityVm => entityVm.id_reading_history,
                opt => opt.MapFrom(entity => entity.id_reading_history))
                .ForMember(entityVm => entityVm.reading_date,
                opt => opt.MapFrom(entity => entity.reading_date))
                .ForMember(entityVm => entityVm.reading_value,
                opt => opt.MapFrom(entity => entity.reading_value))
                .ForMember(entityVm => entityVm.id_meters,
                opt => opt.MapFrom(entity => entity.id_meters))
                .ForMember(entityVm => entityVm.id_housing_and_communal_services,
                opt => opt.MapFrom(entity => entity.id_housing_and_communal_services));
        }
    }
}
