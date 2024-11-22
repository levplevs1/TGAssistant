using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.UpdateQuick_Answers_hcs;
using TelegramBot.Application.src.Entities.Quick_Answers_hcs.Queries.GetQuick_Answers_hcsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Quick_Answers_hcs
{
    public class UpdateQuick_Answers_hcsDto : IMapWith<UpdateQuick_Answers_hcsCommand>
    {
        public string quick_answers_hcs_name { get; set; }
        public string quick_answers_hcs_content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateQuick_Answers_hcsDto, UpdateQuick_Answers_hcsCommand>()
                .ForMember(entityDto => entityDto.quick_answers_hcs_name,
                opt => opt.MapFrom(entity => entity.quick_answers_hcs_name))
                .ForMember(entityDto => entityDto.quick_answers_hcs_content,
                opt => opt.MapFrom(entity => entity.quick_answers_hcs_content));
        }
    }
}
