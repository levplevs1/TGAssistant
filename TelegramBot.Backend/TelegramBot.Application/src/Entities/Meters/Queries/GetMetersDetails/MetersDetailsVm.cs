using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.Application.src.Entities.Meters.Queries.GetMetersDetails
{
    public class MetersDetailsVm : IMapWith<Domain.src.Entities.Meters>
    {
        public int id_meters { get; set; }
        public DateTime instalition_date { get; set; }
        public DateTime? last_reading_date { get; set; }
        public int id_meter_type { get; set; }
        public int id_users { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Meters, MetersDetailsVm>()
                .ForMember(entityVm => entityVm.id_meters,
                opt => opt.MapFrom(entity => entity.id_meters))
                .ForMember(entityVm => entityVm.instalition_date,
                opt => opt.MapFrom(entity => entity.instalition_date))
                .ForMember(entityVm => entityVm.last_reading_date,
                opt => opt.MapFrom(entity => entity.last_reading_date))
                .ForMember(entityVm => entityVm.id_meter_type,
                opt => opt.MapFrom(entity => entity.id_meter_type))
                .ForMember(entityVm => entityVm.id_users,
                opt => opt.MapFrom(entity => entity.id_users));
        }
    }
}
