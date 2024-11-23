using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.Application.src.Entities.Payments.Queries.GetPaymentsDetails
{
    public class PaymentsDetailsVm : IMapWith<Domain.src.Entities.Payments>
    {
        public int id_payments { get; set; }
        public DateTime payments_date { get; set; }
        public double amount { get; set; }
        public int id_users { get; set; }
        public int id_payments_method { get; set; }
        public int id_service_type { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Payments, PaymentsDetailsVm>()
                .ForMember(entityVm => entityVm.id_payments,
                opt => opt.MapFrom(entity => entity.id_payments))
                .ForMember(entityVm => entityVm.payments_date,
                opt => opt.MapFrom(entity => entity.payments_date))
                .ForMember(entityVm => entityVm.amount,
                opt => opt.MapFrom(entity => entity.amount))
                .ForMember(entityVm => entityVm.id_users,
                opt => opt.MapFrom(entity => entity.id_users))
                .ForMember(entityVm => entityVm.id_payments_method,
                opt => opt.MapFrom(entity => entity.id_payments_method))
                .ForMember(entityVm => entityVm.id_service_type,
                opt => opt.MapFrom(entity => entity.id_service_type));
        }
    }
}
