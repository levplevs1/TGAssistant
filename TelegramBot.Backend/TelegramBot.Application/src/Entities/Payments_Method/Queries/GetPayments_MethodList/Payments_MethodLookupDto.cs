using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;

namespace TelegramBot.Application.src.Entities.Payments_Method.Queries.GetPayments_MethodList
{
    public class Payments_MethodLookupDto : IMapWith<Domain.src.Entities.Payments_Method>
    {
        public int id_payments_method { get; set; }
        public string payments_method_name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Payments_Method, Payments_MethodLookupDto>()
                .ForMember(entityVm => entityVm.id_payments_method,
                opt => opt.MapFrom(entity => entity.id_payments_method))
                .ForMember(entityVm => entityVm.payments_method_name,
                opt => opt.MapFrom(entity => entity.payments_method_name));
        }
    }
}
