using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Payments.Commands.CreatePayments;
using TelegramBot.Application.src.Entities.Payments.Queries.GetPaymentsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Domain.src.Entities;

namespace TelegramBot.WebApi.src.EntitiesDto.Payments
{
    public class CreatePaymentsDto : IMapWith<CreatePaymentsCommand>
    {
        public double amount { get; set; }
        public int id_users { get; set; }
        public int id_payments_method { get; set; }
        public int id_service_type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Payments, CreatePaymentsCommand>()
                .ForMember(entityDto => entityDto.amount,
                opt => opt.MapFrom(entity => entity.amount))
                .ForMember(entityDto => entityDto.id_users,
                opt => opt.MapFrom(entity => entity.id_users))
                .ForMember(entityDto => entityDto.id_payments_method,
                opt => opt.MapFrom(entity => entity.id_payments_method))
                .ForMember(entityDto => entityDto.id_service_type,
                opt => opt.MapFrom(entity => entity.id_service_type));
        }
    }
}
