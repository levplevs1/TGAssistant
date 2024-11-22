using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Queries.GetMeter_ReadingsList
{
    public class Meter_ReadingsLookupDto : IMapWith<Domain.src.Entities.Meter_Readings>
    {
        public int id_meter_readings { get; set; }
        public string readings_value { get; set; }
        public string previos_readings_value { get; set; }
        public DateTime readings_date { get; set; }
        public int id_meters { get; set; }
        public int id_housing_and_communal_services { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Meter_Readings, Meter_ReadingsLookupDto>()
                .ForMember(entityVm => entityVm.id_meter_readings,
                opt => opt.MapFrom(entity => entity.id_meter_readings))
                .ForMember(entityVm => entityVm.readings_value,
                opt => opt.MapFrom(entity => entity.readings_value))
                .ForMember(entityVm => entityVm.previos_readings_value,
                opt => opt.MapFrom(entity => entity.previos_readings_value))
                .ForMember(entityVm => entityVm.readings_date,
                opt => opt.MapFrom(entity => entity.readings_date))
                .ForMember(entityVm => entityVm.id_meters,
                opt => opt.MapFrom(entity => entity.id_meters))
                .ForMember(entityVm => entityVm.id_housing_and_communal_services,
                opt => opt.MapFrom(entity => entity.id_housing_and_communal_services));
        }
    }
}
