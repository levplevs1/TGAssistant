using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.Application.src.Entities.Meter_Type.Queries.GetMeter_TypeDetails
{
    public class Meter_TypeDetailsVm : IMapWith<Domain.src.Entities.Meter_Type>
    {
        public int id_meter_type { get; set; }
        public string meter_type_name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Meter_Type, Meter_TypeDetailsVm>()
                .ForMember(entityVm => entityVm.id_meter_type,
                opt => opt.MapFrom(entity => entity.id_meter_type))
                .ForMember(entityVm => entityVm.meter_type_name,
                opt => opt.MapFrom(entity => entity.meter_type_name));
        }
    }
}
