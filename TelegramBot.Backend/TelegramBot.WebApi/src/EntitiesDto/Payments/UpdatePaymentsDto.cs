using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Payments.Commands.UpdatePayments;
using TelegramBot.Application.src.Entities.Payments.Queries.GetPaymentsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Payments
{
    public class UpdatePaymentsDto : IMapWith<UpdatePaymentsCommand>
    {
        public double amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePaymentsDto, UpdatePaymentsCommand>()
                .ForMember(entityDto => entityDto.amount,
                opt => opt.MapFrom(entity => entity.amount));
        }
    }
}
